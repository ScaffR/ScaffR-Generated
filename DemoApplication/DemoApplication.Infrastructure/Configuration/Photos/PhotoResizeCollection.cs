namespace DemoApplication.Infrastructure.Configuration.Photos
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Core.Interfaces.Photos;

    #endregion

    /// <summary>
    /// The photo resize collection.
    /// </summary>
    [ConfigurationCollection(typeof(PhotoResizeElement))]
    public class PhotoResizeCollection : ConfigurationElementCollection, IPhotoResizeCollection
    {
        /// <summary>
        /// The property name.
        /// </summary>
        internal const string PropertyName = "add";

        /// <summary>
        /// The is element name.
        /// </summary>
        /// <param name="elementName">
        /// The element name.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Gets the element name.
        /// </summary>
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public void Add(ProviderSettings provider)
        {
            if (provider != null)
            {
                BaseAdd(provider);
            }
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// The create new element.
        /// </summary>
        /// <returns>
        /// The System.Configuration.ConfigurationElement.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new PhotoResizeElement();
        }

        /// <summary>
        /// The get element key.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The System.Object.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (PhotoResizeElement)element;
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The JamesRocks.Photos.PhotoResizeElement.
        /// </returns>
        public new IPhotoResize this[string key]
        {
            get
            {
                return (PhotoResizeElement)BaseGet(key);
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The JamesRocks.Photos.PhotoResizeElement.
        /// </returns>
        public IPhotoResize this[int index]
        {
            get
            {
                return (PhotoResizeElement)BaseGet(index);
            }

            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index,(PhotoResizeElement) value);
            }
        }

        public new IEnumerator<IPhotoResize> GetEnumerator()
        {
            foreach (PhotoResizeElement x in (ConfigurationElementCollection) this)
            {
                yield return x;
            }
        }
    }
}