using Session09.Core.Domain.People.Repositories;
using Session09.Infra.Data.Command.Sql;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Session09.Infra.Data.Command.Sql.People;
using Session09.Core.ApplicationServices.People.Commands;
using Session09.Core.ApplicationServices.People.CommandHandlers;
using Zamin.Core.Domain.TacticalPatterns;
using Shouldly;
using System.Linq;

namespace Session09.IntegrationTests.ApplicationServices.People
{
    public class PersonCommandRepositoryFixture : IDisposable
    {
        public IPersonCommandRepository PersonCommandRepository { get; }
        public  Session09DbContext DbContext { get; }
        public PersonCommandRepositoryFixture()
        {
            DbContextOptionsBuilder<Session09DbContext> builder = new DbContextOptionsBuilder<Session09DbContext>();
            builder.UseSqlServer("Server =.; Database=PeopleIntegrationTest ;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true");
            DbContext = new Session09DbContext(builder.Options);
            DbContext.Database.EnsureCreated();
            PersonCommandRepository = new PersonCommandRepository(DbContext);
        }
        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
    public class CreateNewPersonCommandHandlerTests:IClassFixture<PersonCommandRepositoryFixture>
    {
        PersonCommandRepositoryFixture fixture;

        public CreateNewPersonCommandHandlerTests(PersonCommandRepositoryFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void when_pass_valid_Input_value_expect_person_create_and_register_to_databse()
        {
            //Arrange
            var command = new CreateNewPersonCommand
            {
                FirstName = "Alireza",
                LastName = "Oroumand",
                Id = Guid.NewGuid()
            };
            
            var commanHandler = new CreateNewPersonCommandHandler(fixture.PersonCommandRepository);

            // Act
            commanHandler.Handle(command);
            //Assert
            var person = fixture.DbContext.People.FirstOrDefault(c => c.Id == BusinessId.FromGuid(command.Id));

            person.ShouldNotBeNull();
            person.FirstName.ShouldBe(command.FirstName);
            person.LastName.ShouldBe(command.LastName);

        }
    }
}
