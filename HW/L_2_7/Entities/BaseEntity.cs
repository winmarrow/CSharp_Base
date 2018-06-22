using System;
using L_2_7.Interfaces;

namespace L_2_7.Entities
{
    [Serializable]
    public class BaseEntity : IEntity
    {
        public BaseEntity(string title)
        {
            Title = title;
        }

        public string Title { get; protected set; }
    }
}