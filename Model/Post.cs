using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Post
    {
        public int Id { get; set; }
        public string NamePost { get; set; }
        public Post ( ) { }
        public Post ( int id, string namePost)
        {
            this.Id = id;
            this.NamePost = namePost;
        }
    }
}
