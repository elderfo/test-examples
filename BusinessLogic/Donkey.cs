using System;

namespace BusinessLogic
{
    public class Donkey
    {
        public int Id { get; }
        public string Name { get; }

        public Donkey(int id,  String name)
        {
            Id = id;
            Name = name;
        }
    }
}