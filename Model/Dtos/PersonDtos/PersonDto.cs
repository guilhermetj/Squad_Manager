﻿using Squad_Manager.Model.Dtos.SquadDtos;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;

namespace Squad_Manager.Model.Dtos.PersonDtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public UserDetailsDto User { get; set; }
        public SquadDto Squad { get; set; }
    }
}
