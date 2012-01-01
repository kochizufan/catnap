using System;
using Catnap.Impl;

namespace Catnap.Tests.Core.Models
{
    public class PostGuid : EntityGuid
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public PersonGuid Poster { get; set; }
        public DateTime? DatePosted { get; set; }
    }

    public class Post : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Person Poster { get; set; }
        public DateTime? DatePosted { get; set; }
    }
}