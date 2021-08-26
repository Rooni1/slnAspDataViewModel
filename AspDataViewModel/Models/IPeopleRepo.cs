﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDataViewModel.Models
{
    public interface IPeopleRepo
    {
        Person Create(string name,string phoneNumber,string city);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
