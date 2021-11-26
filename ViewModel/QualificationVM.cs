using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class PostVM
    {
        public int MaxIdQ()
        {
            int max = 0;
            foreach (var s in this.ListPost)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Post> ListPost
        {
            get;
            set;
        } =
    new ObservableCollection<Post>();
        public PostVM()
        {
            this.ListPost.Add(new Post
            {
                Id = 1,
                NamePost = "Доцент"
            });
            this.ListPost.Add(new Post
            {
                Id = 2,
                NamePost = "Профессор"
            });
        }
    }
}