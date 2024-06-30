using System;
using System.Text.Json;
using Xunit;

namespace Types
{
    
    public class Dynamic
    {
        const string json_obj = "{ \"StringType\": \"abc\", \"IntType\": 123, \"BoolType\": true, \"DecimalType\": 12.34 }";
        const string json_arr = "[1, 2, 3]";

        [Fact]
        public void Anonymous_RuntimeType()
        {
            dynamic obj = new { StringType = "abc", IntType = 123, BoolType = true, DoubleType = 12.34 };

            Assert.True(obj.StringType is string);
            Assert.True(obj.IntType is int);
            Assert.True(obj.BoolType is bool);
            Assert.True(obj.DecimalType is double);
        }

        [Fact]
        public void Json_Deserialize_RuntimeType_System_Text_Json()
        {
            var d_obj = System.Text.Json.JsonSerializer.Deserialize<dynamic>(json_obj);
            var d_arr = System.Text.Json.JsonSerializer.Deserialize<dynamic>(json_arr);

            // Runtime Type is System.Text.Json.JsonElement
            Assert.True(d_obj is System.Text.Json.JsonElement);
            Assert.True(d_arr is System.Text.Json.JsonElement);

            // Use type information accordingly
            Assert.Equal(System.Text.Json.JsonValueKind.Object, d_obj.ValueKind);
            Assert.Equal(System.Text.Json.JsonValueKind.Array, d_arr.ValueKind);

            var json_elm_obj = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(json_obj);
            Assert.Equal(System.Text.Json.JsonValueKind.String, json_elm_obj.GetProperty("StringType").ValueKind);
            Assert.Equal("abc", json_elm_obj.GetProperty("StringType").ToString());

            var json_elm_arr = System.Text.Json.JsonSerializer.Deserialize<int[]>(json_arr);
            Assert.True(json_elm_arr.Length > 0);
        }

        [Fact]
        public void Json_Deserialize_RuntimeType_Newtonsoft_Json()
        {
            // Runtime Type: Newtonsoft.Json.Linq.JObject
            var d_obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json_obj);
            Assert.True(d_obj is Newtonsoft.Json.Linq.JObject);

            // Runtime Type: Newtonsoft.Json.Linq.JArray
            var d_arr = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json_arr);
            Assert.True(d_arr is Newtonsoft.Json.Linq.JArray);
        }
    }
}
