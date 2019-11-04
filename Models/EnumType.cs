﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class EnumType
    {
        public string Name { get; private set; }
        public bool IsFlags { get; private set; }
        public string NameSpace { get; private set; }
        public string Type { get { return $"{this.NameSpace}.{this.Name}"; } }
        public IEnumerable<EnumMember> Members { get; private set; }
        
        public EnumType(XElement sourceElement)
        {
            Name = sourceElement.Attribute("Name")?.Value;
            IsFlags = sourceElement.Attribute("IsFlags")?.Value == "true";
            NameSpace = sourceElement.Parent?.Attribute("Namespace")?.Value;
            Members = sourceElement.Descendants().Where(a => a.Name.LocalName == "Member")
                .Select(propElement => new EnumMember()
                {
                    Name = propElement.Attribute("Name")?.Value,
                    Value = propElement.Attribute("Value")?.Value
                }).ToList();
        }
    }
}
