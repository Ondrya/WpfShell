using Fake = Bogus;
using ComboboxBindings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ComboboxBindings.ViewModels
{
    public class MainWindowViewModels : BaseViewModel
    {
        private List<Person> tempPersons;

        private ObservableCollection<Person> persons;
        private Person selectedPerson;
        
        public Person SelectedPerson
        {
            get => selectedPerson;
            set 
            { 
                selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons
        {
            get => persons;
            set { 
                persons = value;
                OnPropertyChanged();
            }
        }

        


        public MainWindowViewModels()
        {
            Persons = new ObservableCollection<Person>();

            tempPersons = new Fake.Faker<Person>()
                .RuleFor(p => p.NameFirst, f => f.Person.FirstName)
                .RuleFor(p => p.NameLast, f => f.Person.LastName)
                .Generate(20);

            foreach (var person in tempPersons)
            {
                Random addressQuantity = new Random();

                person.Addresses = new Fake.Faker<Address>()
                    .RuleFor(a => a.PostCode, f => f.Address.ZipCode())
                    .RuleFor(a => a.CityName, f => f.Address.City())
                    .RuleFor(a => a.Street, f => f.Address.StreetName())
                    .RuleFor(a => a.Hause, f => f.Address.BuildingNumber())
                    .Generate(addressQuantity.Next(1, 15));
            }

            fillPersons();
        }

        private void fillPersons ()
        {
            Persons.Clear();
            foreach (var item in tempPersons)
            {
                Persons.Add(item);
            }
        }
    }

}
