using CalculadoraImpostos_SergioDias.Domain;
using CalculadoraImpostos_SergioDias.Repositories;
using CalculadoraImpostos_SergioDias.Repositories.Base;
using System;
using System.IO;
using Xunit;

namespace CalculadoraImpostos_SergioDias.Services.Tests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void UnderLowerLimitReturnsZero()
        {
            //arrange
            double input = 22847.76;
            double expected = 0;
            PersonTaxInfoRepository personRepository = new PersonTaxInfoRepository(new BaseRepository<Person>());
            TaxCalculator taxCalculator = new(personRepository);

            //act
            double actual = taxCalculator.TaxCalculation(input);

            //assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(761.42, 33000.0)]
        [InlineData(1742.43, 40000.0)]
        [InlineData(3616.49, 50000.0)]
        [InlineData(6067.68, 60000.0)]
        public void ResultadoCalculoParaDiferentesFaixas(double expected, double input)
        {
            //arrange
            PersonTaxInfoRepository personRepository = new PersonTaxInfoRepository(new BaseRepository<Person>());
            TaxCalculator taxCalculator = new(personRepository);

            //act
            double actual = Math.Round(taxCalculator.TaxCalculation(input), 2);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotRegisterPersonAlreadyRegistered()
        {
            //arrange
            if (File.Exists("Person.txt"))
            {
                File.Delete("Person.txt");
            }
            PersonTaxInfoRepository personRepository = new PersonTaxInfoRepository(new BaseRepository<Person>());
            Person testPerson = new();
            testPerson.Cpf = "99999999999";
            testPerson.Name = "Person Not To Be Registered";
            personRepository.SavePerson(testPerson);
            TaxCalculator taxCalculator = new(personRepository);
            bool expected = false;
            bool expected2 = true;
            int expected3 = 2;

            Person testPerson2 = new();
            testPerson2.Cpf = "99999999988";
            testPerson2.Name = "Person To Be Registered";

            //act
            bool actual = taxCalculator.RegisterTaxValue(testPerson);
            bool actual2 = taxCalculator.RegisterTaxValue(testPerson2);
            int actual3 = personRepository.ListAllRegister().Count;

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);
            Assert.Equal(expected3, actual3);

            File.Delete("Person.txt");
        }

        [Fact]
        public void ReturnPersonTaxInfoByCpf()
        {
            //arrange
            if (File.Exists("Person.txt"))
            {
                File.Delete("Person.txt");
            }
            PersonTaxInfoRepository personRepository = new PersonTaxInfoRepository(new BaseRepository<Person>());
            Person testPerson = new();
            testPerson.Cpf = "99999999999";
            testPerson.Tax = 12345.1;
            personRepository.SavePerson(testPerson);
            TaxCalculator taxCalculator = new(personRepository);
            Person expected = testPerson;

            //act
            Person actual = taxCalculator.SearchTaxInfo(testPerson.Cpf);
            Person actual2 = taxCalculator.SearchTaxInfo("99999999111");

            //assert
            Assert.Equal(expected, actual);
            Assert.Null(actual2);

            File.Delete("Person.txt");
        }
        [Fact]
        public void ReturnListOfPeople()
        {
            //arrange
            if (File.Exists("Person.txt"))
            {
                File.Delete("Person.txt");
            }
            PersonTaxInfoRepository personRepository = new PersonTaxInfoRepository(new BaseRepository<Person>());
            Person testPerson1 = new();
            Person testPerson2 = new();
            Person testPerson3 = new();
            personRepository.SavePerson(testPerson1);
            personRepository.SavePerson(testPerson2);
            personRepository.SavePerson(testPerson3);
            TaxCalculator taxCalculator = new(personRepository);
            int expected = 3;


            //act
            int actual = taxCalculator.ListTaxInfo().Count;

            //assert
            Assert.Equal(expected, actual);

            File.Delete("Person.txt");
        }

    }
}