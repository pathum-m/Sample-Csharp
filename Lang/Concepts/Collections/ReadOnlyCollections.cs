using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lang.Collections
{
    public class ReadOnlyCollections
    {
        [Fact]
        public void ChangeCollectionItem()
        {
            var list = new List<Component> 
            { 
                new Component { Value = 1, Key = "A" },
                new Component { Value = 2, Key = "B" },
                new Component { Value = 3, Key = "C" },
            };

            var last = list.Last();
            last.Value = 4;

            Assert.Equal(4, list.First(a => a.Key == "C").Value);

            var readOnlyList = list.AsReadOnly();

            // Internal elements can be changed.

            var first = readOnlyList.First();
            first.Value = 4;

            Assert.Equal(4, list.First(a => a.Key == "A").Value);
        }

        [Fact]
        public void AddRemoveOrReplaceCollectionItem()
        {
            var list = new List<Component>
            {
                new Component { Value = 1, Key = "A" },
                new Component { Value = 2, Key = "B" },
                new Component { Value = 3, Key = "C" },
            };

            list.Add(new Component { Value = 4, Key = "D" });
            list.Remove(list.First());

            var readOnly = list.AsReadOnly();

            // Compilation error
            //readOnly.Add(new A { Value = 4, Key = "D" });
            //readOnly.Remove(readOnly.First());
        }
    }    
}
