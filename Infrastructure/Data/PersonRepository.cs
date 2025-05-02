using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }
        //connect the database
        private SqlConnection CreateConnection()
        {
            var connectionString = _context.Database.GetConnectionString();
            return new SqlConnection(connectionString);
        }
        public async Task AddAsync(Person person)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new
                {
                    person.Identification,
                    person.FirstName,
                    person.LastName,
                    person.SecondLastName,
                    person.Email

                };

                var query = "InsertPerson";

                var response = await connection.QueryAsync<Person>(
                    query,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task DeleteAsync(int id)
        {
            using SqlConnection connection = CreateConnection();
            await connection.OpenAsync();

            await connection.ExecuteAsync(
                "DeletePerson",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<List<Person>> GetAllAsync()
        {
            using SqlConnection connection = CreateConnection();
            await connection.OpenAsync();

            var persons=await connection.QueryAsync<Person>
                ("GetAllPersons", commandType:CommandType.StoredProcedure);
            return persons.ToList();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            using SqlConnection connection = CreateConnection();
            await connection.OpenAsync();

            var persons = await connection.QueryFirstOrDefaultAsync<Person>
                ("GetPersonByID",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
            return persons;
        }

        public async Task UpdateAsync(Person person)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new
                {
                    person.Id,
                    person.Identification,
                    person.FirstName,
                    person.LastName,
                    person.SecondLastName,
                    person.Email

                };

                var query = "UpdatePerson";

                var response = await connection.QueryAsync<Person>(
                    query,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }
    }
}
