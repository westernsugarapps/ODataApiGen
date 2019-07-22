using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Abstracts;

namespace Od2Ts.Angular
{
    public class AngularPackage : Od2Ts.Abstracts.Package
    {
        public bool UseInterfaces {get;set;}
        public bool UseReferences {get;set;}
        public Angular.Module Module { get; private set; }
        public Angular.Config Config { get; private set; }
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Enum> Enums { get; private set; }
        public ICollection<Angular.Service> Services { get; private set; }
        public ICollection<Angular.Model> Models { get; private set; }


        public AngularPackage(string endpointName, string metadataPath, bool secure, string version) : base(endpointName, metadataPath, secure, version)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Enums = new List<Angular.Enum>();
            Services = new List<Angular.Service>();
            Models = new List<Angular.Model>();
        }

        public override void LoadMetadata(MetadataReader reader)
        {
            this.AddEnums(reader.EnumTypes);
            this.AddModels(reader.ComplexTypes, UseInterfaces);
            this.AddModels(reader.EntityTypes, UseInterfaces);
            this.AddServices(reader.EntitySets, UseInterfaces, UseReferences);
        }

        public void AddEnums(IEnumerable<Models.EnumType> enums)
        {
            foreach (var e in enums)
            {
                this.Enums.Add(new Angular.Enum(e));
            }
        }

        public void AddModels(IEnumerable<Models.EntityType> entities, bool inter)
        {
            foreach (var m in entities)
            {
                if (inter) {
                    this.Models.Add(new Angular.ModelInterface(m));
                } else {
                    this.Models.Add(new Angular.ModelClass(m));
                }
            }
        }

        public void AddModels(IEnumerable<Models.ComplexType> complexs, bool inter)
        {
            foreach (var c in complexs)
            {
                if (inter) {
                    this.Models.Add(new Angular.ModelInterface(c));
                } else {
                    this.Models.Add(new Angular.ModelClass(c));
                }
            }
        }

        public void AddServices(IEnumerable<Models.EntitySet> sets, bool inter, bool refe)
        {
            foreach (var s in sets)
            {
                if (inter) {
                    this.Services.Add(new Angular.ServiceEntity(s, refe));
                } else {
                    this.Services.Add(new Angular.ServiceModel(s, refe));
                }
            }
        }

        public void ResolveDependencies()
        {
            foreach (var enumm in Enums)
            {
            }
            foreach (var model in Models)
            {
                if (!String.IsNullOrEmpty(model.EdmStructuredType.BaseType))
                {
                    var baseInter = this.Models.FirstOrDefault(m => m.EdmStructuredType.Type == model.EdmStructuredType.BaseType);
                    model.SetBase(baseInter);
                }
                var types = model.ImportTypes;
                model.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                model.Dependencies.AddRange(
this.Models.Where(e => e != model && types.Contains(e.EdmStructuredType.Type))
                );
            }
            foreach (var service in Services)
            {
                var inter = this.Models.FirstOrDefault(m => m.EdmStructuredType.Name == service.EdmEntityTypeName);
                if (inter != null)
                {
                    service.SetModel(inter);
                }
                var types = service.ImportTypes;
                service.Dependencies.AddRange(
this.Enums.Where(e => types.Contains(e.EdmEnumType.Type))
                );
                service.Dependencies.AddRange(
this.Models.Where(e => types.Contains(e.EdmStructuredType.Type))
                );
            }
            this.Module.Dependencies.AddRange(this.Services);
            this.Config.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Enums);
            this.Index.Dependencies.AddRange(this.Models);
            this.Index.Dependencies.AddRange(this.Services);
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Enums.Select(e => e.Directory)
                .Union(this.Models.Select(m => m.Directory))
                .Union(this.Services.Select(s => s.Directory))
                .Distinct();
        }
        public override IEnumerable<Renderable> Renderables { get {
            var renderables = new List<Renderable>();
            renderables.AddRange(this.Enums);
            renderables.AddRange(this.Models);
            renderables.AddRange(this.Services);
            renderables.Add(this.Module);
            renderables.Add(this.Config);
            renderables.Add(this.Index);
            return renderables;
        }}
    }
}