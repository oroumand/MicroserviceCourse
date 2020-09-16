using Moq;
using Session09.Core.ApplicationServices.People.CommandHandlers;
using Session09.Core.ApplicationServices.People.Commands;
using Session09.Core.Domain.People.Entities;
using Session09.Core.Domain.People.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Session09.UnitTests.ApplicationServices.People
{
    public class CreateNewPersonCommandHandlerTests
    {
        [Fact]
        public void when_pass_valid_Input_value_expect_person_create_and_register()
        {
            //Arrange 

            var command = new CreateNewPersonCommand
            {
                FirstName = "Alireza",
                LastName = "Oroumand",
                Id = Guid.NewGuid()
            };
            var moqPersonRepository =new  Moq.Mock<IPersonCommandRepository>();
            moqPersonRepository.Setup(c => c.Add(It.IsAny<Person>()));
            
            var commanHandler = new CreateNewPersonCommandHandler(moqPersonRepository.Object);

            // Act
            commanHandler.Handle(command);
            //Assert
            moqPersonRepository.Verify(mock => mock.Add(It.IsAny<Person>()), Times.Once());
        }
    }
}
