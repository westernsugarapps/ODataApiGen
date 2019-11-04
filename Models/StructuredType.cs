﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public abstract class StructuredType 
    {
        public StructuredType(XElement sourceElement)
        {
            NameSpace = sourceElement.Parent?.Attribute("Namespace")?.Value;
            Name = sourceElement.Attribute("Name")?.Value;
            BaseType = sourceElement.Attribute("BaseType")?.Value;

            Keys = sourceElement.Descendants()
                    .Where(a => a.Name.LocalName == "Key")
                    .Descendants()
                    .Select(element => new PropertyRef() {
                        Name = element.Attribute("Name")?.Value,
                        Alias = element.Attribute("Alias")?.Value
                    })
                    .ToList();

            Properties = sourceElement.Descendants().Where(a => a.Name.LocalName == "Property")
                .Select(element => new Property()
                    {
                        IsCollection = element.Attribute("Type")?.Value.StartsWith("Collection(") ?? false,
                        Name = element.Attribute("Name")?.Value,
                        MaxLength = element.Attribute("MaxLength")?.Value,
                        IsNullable = element.Attribute("Nullable")?.Value == "true",
                        Type = element.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')'),
                    }).ToList();

            NavigationProperties = sourceElement.Descendants().Where(a => a.Name.LocalName == "NavigationProperty")
                .Select(element => new NavigationProperty()
                    {
                        Name = element.Attribute("Name")?.Value.Split(".").Last(),
                        FullName = element.Attribute("Name")?.Value,
                        MaxLength = null,
                        IsNullable = true,
                        IsCollection = element.Attribute("Type")?.Value.StartsWith("Collection(") ?? false,
                        Partner = element.Attribute("Partner")?.Value,
                        Type = element.Attribute("Type")?.Value.TrimStart("Collection(".ToCharArray()).TrimEnd(')'),
                        ReferentialConstraint = element.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("Property")?.Value,
                        ReferencedProperty = element.Descendants().SingleOrDefault(a => a.Name.LocalName == "ReferentialConstraint")?.Attribute("ReferencedProperty")?.Value
                }).ToList();
        }
        public string NameSpace { get; private set; }
        public string Name { get; private set; }
        public string BaseType { get; private set; }
        public string Type { get { return $"{this.NameSpace}.{this.Name}"; } }
        public bool IsCompositeKey { get { return this.Keys.Count() > 1; } }
        public List<PropertyRef> Keys { get; private set; }
        public List<Property> Properties { get; private set; }
        public List<NavigationProperty> NavigationProperties { get; set; }
    }
}
