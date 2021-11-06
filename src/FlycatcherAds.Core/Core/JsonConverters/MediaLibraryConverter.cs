using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using FlycatcherAds.Models;

namespace FlycatcherAds.Core.JsonConverters
{
    public class MediaLibraryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(BaseMediaLibrary).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<BaseMediaLibrary> mediaLibraries = new List<BaseMediaLibrary>();
            var array = JArray.Load(reader);

            foreach (var item in array)
            {
                var type = (string) ((JObject) item).Property("media_type");

                switch (type)
                {
                    case "IMAGE":
                        mediaLibraries.Add(((JObject)item).ToObject<ImageLibrary>(serializer));
                        break;
                    case "VIDEO":
                        mediaLibraries.Add(((JObject)item).ToObject<VideoLibrary>(serializer));
                        break;
                }
            }

            return mediaLibraries.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}