using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Class_String
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string edit)
        {
            this.Content = edit;
        }

        public void ChangeAuthor(string changeAuthor)
        {
            this.Author = changeAuthor;
        }

        public void Rename(string rename)
        {
            this.Title = rename;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
