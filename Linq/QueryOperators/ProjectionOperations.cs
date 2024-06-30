using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StandardQueryOperators
{
    public class ProjectionOperations
    {
        [Fact]
        public void SelectMany()
        {
            var strgs = new List<string>() { "aaa bb ccc dd", "aaa ee ff ggg" };

            var queryExpression = from strgOuter in strgs
                                  from strgInner in strgOuter.Split(" ")
                                  select strgInner;

            Assert.Equal(8, queryExpression.Count());

            var methodExpression = strgs.SelectMany(strg => strg.Split(" "));

            Assert.Equal(8, methodExpression.Count());

        }

        [Fact]
        public void Zip()
        {
            var seq1 = new List<int>() { 0, 2, 4, 6 };
            var seq2 = new List<int>() { 1, 3, 5, 7, 9 };

            var zippedSeq = seq1.Zip(seq2);

            Assert.Equal(4, zippedSeq.Count());
            var last = zippedSeq.Last();
            Assert.Equal(6, last.First);
            Assert.Equal(7, last.Second);
        }

        [Fact]
        public void Flattening()
        {
            var c = new List<NestedEntity>
            {
                new NestedEntity
                {
                    X = 1,
                    Y = 2,
                    C = new List<NestedEntity>
                    {
                        new NestedEntity
                        {
                            X = 11,
                            Y = 22,
                            C = new List<NestedEntity>
                            {
                                new NestedEntity
                                {
                                    X = 1111,
                                    Y = 2221
                                },
                                new NestedEntity
                                {
                                    X = 1112,
                                    Y = 2222
                                }
                            }
                        }
                    }
                },
                new NestedEntity
                {
                    X = 3,
                    Y = 4,
                    C = new List<NestedEntity>
                    {
                        new NestedEntity
                        {
                            X = 33,
                            Y = 44,
                            C = new List<NestedEntity>
                            {
                                new NestedEntity
                                {
                                    X = 3331,
                                    Y = 4441
                                },
                                new NestedEntity
                                {
                                    X = 3332,
                                    Y = 4442
                                }
                            }
                        }
                    }
                }
            };

            var c2 = c.SelectMany(i1 => 
                        i1.C.SelectMany(i2 => 
                            i2.C.Select(i3 => (X1 : i1.X, X2 : i2.X, X3 : i3.X))));

            Assert.Equal(4, c2.Count());
            Assert.Equal(1, c2.First().X1);
            Assert.Equal(11, c2.First().X2);
            Assert.Equal(1111, c2.First().X3);
        }
    }
}
