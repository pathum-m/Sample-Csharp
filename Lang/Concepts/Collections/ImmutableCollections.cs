using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Immutable;
using Xunit;

namespace Lang.Collections
{
    public class ImmutableCollections
    {
        ImmutableList<Component> _immutableList;

        public ImmutableCollections()
        {
            _immutableList = ImmutableList.Create(
                new Component { Value = 1, Key = "A" },
                new Component { Value = 2, Key = "B" },
                new Component { Value = 3, Key = "C" });
        }

        [Fact]
        public void AddingItemCreatesNewList()
        {
            var immutableList2 = _immutableList.Add(new Component());

            Assert.NotEqual(_immutableList, immutableList2);
        }

        [Fact]
        public void ReplaceElementCreatesNewList()
        {
            var immutableList2 = _immutableList.Replace(_immutableList[1], new Component { Value = 21, Key = "B" });

            Assert.Equal(2, _immutableList[1].Value);
            Assert.Equal(21, immutableList2[1].Value);
        }

        [Fact]
        public void NoProtectionOverChangingIndividualItemProperties()
        {
            _immutableList[0].Value = 4;

            Assert.Equal(4, _immutableList.First().Value);
        }
    }
}
