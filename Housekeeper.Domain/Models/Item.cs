using IFramework.Infrastructure;
using System;

namespace Housekeeper.Domain.Models
{
    /// <summary>
    ///     物品
    /// </summary>
    public class Item : AggregateRoot
    {
        protected Item() { }

        public Item(string name,
                    string tags,
                    ItemType type,
                    DateTime? productionDate = null,
                    DateTime? expireDate = null,
                    Media[] medias = null)
        {
            Id = ObjectId.GenerateNewId()
                         .ToString();
            Name = name;
            Tags = tags;
            Type = type;
            ProductionDate = productionDate;
            ExpireDate = expireDate ?? DateTime.MaxValue;
            Medias = medias;
        }

        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Tags { get; protected set; }
        public ItemType Type { get; protected set; }
        public DateTime? ProductionDate { get; protected set; }
        public DateTime ExpireDate { get; protected set; }
        public string MediasJson { get; protected set; }
        public Media[] Medias
        {
            get => MediasJson.ToJsonObject<Media[]>();
            set => MediasJson = value.ToJson();
        }
    }
}