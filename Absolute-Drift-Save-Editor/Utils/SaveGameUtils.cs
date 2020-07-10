using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Absolute_Drift_Save_Editor.Utils
{
	public static class SaveGameUtils
    {		
		public static byte[] ConvertDictionaryToByteArray(List<KeyValuePairSerializeable> saveKeys)
		{			
			MemoryStream memoryStream = new MemoryStream();
			XmlWriter xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings
			{
				Indent = true,
				Encoding = Encoding.UTF8
			});
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KeyValuePairSerializeable[]));
			xmlSerializer.Serialize(xmlWriter, saveKeys.ToArray());
			return memoryStream.GetBuffer();
		}

		public static List<KeyValuePairSerializeable> ConvertByteArrayToDictionary(byte[] bytes)
		{
			if (bytes == null)
			{
				return null;
			}
			KeyValuePairSerializeable[] array = null;
			MemoryStream stream = new MemoryStream(bytes);
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(KeyValuePairSerializeable[]));
			try
			{
				array = (KeyValuePairSerializeable[])xmlSerializer.Deserialize(stream);
			}
			catch (Exception)
			{
				return null;
			}

			return array.ToList();
		}
	}

    public sealed class KeyValuePairSerializeable
    {
        public KeyValuePairSerializeable()
        {
            Key = "";
            Value = 0;
        }

        public KeyValuePairSerializeable(string key, object value)
        {
            Key = key;
            Value = value;
        }

        [XmlElement(ElementName = "key")]
        public string Key
        {
            get;
            set;
        }

        [XmlElement(ElementName = "value")]
        public object Value
        {
            get;
            set;
        }
    }
}
