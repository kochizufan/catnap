﻿using System;
using System.Collections.Generic;

namespace Catnap.Tests.Core.Models
{
    public class ForumGuid : EntityGuid
    {
        private IEnumerable<PostGuid> posts = new List<PostGuid>();

        public string Name { get; set; }
        public TimeSpan? TimeOfDayLastUpdated { get; set; }
        public IEnumerable<PostGuid> Posts
        {
            get { return posts;  }
            set { posts = value;  }
        }
    }

    public class Forum : EntityInt
    {
        private IEnumerable<Post> posts = new List<Post>();

        public string Name { get; set; }
        public TimeSpan? TimeOfDayLastUpdated { get; set; }
        public IEnumerable<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }
    }
}