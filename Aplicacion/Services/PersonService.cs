using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task AddAsync(PersonDTO person)
        {
            var personEntity = new Core.Entities.Person
            {
                Identification = person.Identification,
                FirstName = person.FirstName,
                LastName = person.LastName,
                SecondLastName = person.SecondLastName,
                Email = person.Email
            };
            await _personRepository.AddAsync(personEntity);

        }

        public async Task DeleteAsync(int id)
        {
           await _personRepository.DeleteAsync(id);

        }

        public async Task<List<PersonDTO>> GetAllAsync()
        {
          var persons = await _personRepository.GetAllAsync();
            return persons.Select(p=> new PersonDTO
            {
                Id=p.Id,
                Identification = p.Identification,
                FirstName = p.FirstName,
                LastName = p.LastName,
                SecondLastName = p.SecondLastName,
                Email = p.Email
            }).ToList();
        }

        public async Task<PersonDTO> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return person == null ? null : new PersonDTO
            {
                Id = person.Id,
                Identification = person.Identification,
                FirstName = person.FirstName,
                LastName = person.LastName,
                SecondLastName = person.SecondLastName,
                Email = person.Email
            };
        }

        public Task UpdateAsync(PersonDTO person)
        {
           var personEntity = new Core.Entities.Person
           {
               Id=person.Id,
               Identification = person.Identification,
               FirstName = person.FirstName,
               LastName = person.LastName,
               SecondLastName = person.SecondLastName,
               Email = person.Email
           };
            return _personRepository.UpdateAsync(personEntity);
        }
    }
}
