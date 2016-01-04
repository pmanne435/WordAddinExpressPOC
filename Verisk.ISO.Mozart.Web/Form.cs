using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Verisk.ISO.Mozart.Web
{
    public class Form
    {
        // [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public ObjectId Id { get; set; }

        public string FormNumber { get; set; }

        public string FormTitle { get; set; }

        public string[] Tags{ get; set; }

        public List<Comments> Comments { get; set; }

        [BsonIgnore]
        public byte[] Data { get; set; }

        public string FileName { get; set; }

        public string FileId { get; set; }

        public string ManualRules { get; set; }

        public string FileContent { get; set; }

    }

    public class Comments
    {
        public string Text { get; set; }

        public string Commenter { get; set; }
    }
}