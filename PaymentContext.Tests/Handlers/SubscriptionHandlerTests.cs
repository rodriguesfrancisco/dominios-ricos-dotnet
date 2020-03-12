using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTest
    {

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Wayne";
            command.LastName = "Last";
            command.Document = "99999999999";
            command.Email = "f@g2.com";
            command.BarCode = "123123123";
            command.BoletoNumber = "123123123";
            command.PaymentNumber = "123123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Corp";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "f@dc.com";
            command.Street = "asdasd";
            command.Number = "asdasda";
            command.Neighbourhood = "asdaasd";
            command.City = "as";
            command.State = "as";
            command.Country = "as";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
