using Session09.Core.Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Zamin.Core.Domain.TacticalPatterns;
using Shouldly;
using System.Linq;
using Session09.Core.Domain.People.Events;
using Session09.Core.Domain.People.Exceptions;

namespace Session09.UnitTests.Core.People.Entities
{
    public class PersonTests
    {
        [Fact]
        public void when_pass_valid_Input_value_expect_person_create()
        {
            //Arrange
            string firstName = "Alrieza";
            string lastName = "Oroumand";
            BusinessId personId = BusinessId.FromGuid(Guid.NewGuid());
            HashSet<string> tags = new HashSet<string> { "Tag01" };

            //Act
            var person = Person.Create(personId, firstName, lastName);

            //Assert
            person.ShouldNotBeNull();
            person.Id.ShouldBe(personId);
            person.FirstName.ShouldBe(firstName);
            person.LastName.ShouldBe(lastName);
            person.GetEvents().Count().ShouldBe(1);
            var @event = person.GetEvents().First();
            @event.ShouldBeOfType<PersonCreated>();
        }
        [Fact]
        public void when_pass_invalid_id_expect_throw_invalid_person_id_exception()
        {
            //Arrange
            string firstName = "Alrieza";
            string lastName = "Oroumand";
            BusinessId personId = null;
            HashSet<string> tags = new HashSet<string> { "Tag01" };

            //Act
            var exception = Record.Exception(() => Person.Create(personId, firstName, lastName));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPersonIdException>();
        }
    }
}
