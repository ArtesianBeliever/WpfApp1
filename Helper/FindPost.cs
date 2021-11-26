using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindPost
    {
        int id;
        public FindPost(int id)
        {
            this.id = id;
        }
        public bool PostPredicate(Post post)
        {
            return post.Id == id;
        }
    }
}
