﻿namespace Squad_Manager.Model.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public int Squad_Id { get; set; }
        public Squad Squad { get; set; }
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
