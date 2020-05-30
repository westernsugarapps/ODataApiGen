using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Package : ODataApiGen.Abstracts.Package, ILiquidizable
    {
        public Angular.Module Module { get; private set; }
        public Angular.Config Config { get; private set; }
        public Angular.Index Index { get; private set; }
        public ICollection<Angular.Schema> Schemas { get; private set; }
        public Package(string name, string serviceRootUrl) : base(name, serviceRootUrl)
        {
            this.Module = new Module(this);
            Config = new Angular.Config(this);
            Index = new Angular.Index(this);
            Schemas = new List<Angular.Schema>();
        }

        public override void Build(bool models)
        {
            foreach (var schema in Program.Metadata.Schemas)
            {
                this.Schemas.Add(new Angular.Schema(schema, this.Name, models));
            }
        }
        public void ResolveDependencies()
        {
            foreach (var schema in Schemas)
                schema.ResolveDependencies();
            // Module
            this.Module.Dependencies.AddRange(this.Schemas.Select(s => s.Api));
            this.Module.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            // Config
            this.Config.Dependencies.AddRange(this.Schemas);
            // Index
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Enums));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.EnumConfigs));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Entities));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Models));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Collections));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.EntityConfigs));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
            this.Index.Dependencies.AddRange(this.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.ServiceConfigs)));
        }

        public IEnumerable<string> GetAllDirectories()
        {
            return this.Schemas.SelectMany(s => s.GetAllDirectories())
                .Distinct();
        }

        public object ToLiquid()
        {
            return new
            {
                Name = this.Name.ToLower(),
                ServiceRootUrl = this.ServiceRootUrl,
                Creation = DateTime.Now,
                Schemas = this.Schemas
            };
        }

        public override IEnumerable<Renderable> Renderables
        {
            get
            {
                var renderables = new List<Renderable>();
                renderables.Add(this.Module);
                renderables.Add(this.Config);
                renderables.Add(this.Index);
                renderables.AddRange(this.Schemas);
                renderables.AddRange(this.Schemas.SelectMany(s => s.Renderables));
                return renderables;
            }
        }
    }
}