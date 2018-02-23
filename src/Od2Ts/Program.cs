﻿using System;
using System.IO;
using Od2Ts.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Od2Ts
{
    class Program
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        public static ILogger Logger { get; } = Program.CreateLogger<Program>();
        public static IConfiguration Configuration { get; set; }
        public static string MetadataPath { get; set; }
        public static string EndpointName { get; set; }
        public static string Output { get; set; }
        public static bool PurgeOutput { get; set; }

        static void Main(string[] args)
        {
            LoggerFactory
                .AddConsole()
                .AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.json");
            Configuration = builder.Build();

            MetadataPath = Configuration.GetValue<string>("MetadataPath");
            EndpointName = Configuration.GetValue<string>("EndpointName");
            Output = Configuration.GetValue<string>("Output");
            PurgeOutput = Configuration.GetValue<bool>("PurgeOutput");

            var directoryManager = new DirectoryManager(Output);
            var templateRenderer = new TemplateRenderer(Output);

            Configuration.GetSection("Templates").Bind(templateRenderer);
            if (true)
            {
                Configuration.GetSection("AngularTemplates").Bind(templateRenderer);
            }
            else
            {
                Configuration.GetSection("AureliaTemplates").Bind(templateRenderer);
            }
            templateRenderer.LoadTemplates();
            
            var xml = Loader.Load(MetadataPath);
            var metadataReader = new MetadataReader(xml);

            directoryManager.PrepareOutput(PurgeOutput);

            Logger.LogInformation("Preparing namespace structure");
            directoryManager.PrepareNamespaceFolders(metadataReader.EnumTypes);
            directoryManager.PrepareNamespaceFolders(metadataReader.EntitySets);
            directoryManager.PrepareNamespaceFolders(metadataReader.EntityTypes);
            directoryManager.PrepareNamespaceFolders(metadataReader.ComplexTypes);

            directoryManager.DirectoryCopy("./StaticContent", Output, true);

            templateRenderer.CreateContext(MetadataPath, "4.0");

            templateRenderer.CreateEntityTypes(metadataReader.EntityTypes);
            templateRenderer.CreateComplexTypes(metadataReader.ComplexTypes);

            templateRenderer.CreateEnums(metadataReader.EnumTypes);

            templateRenderer.CreateServicesForEntitySets(metadataReader.EntitySets);

            templateRenderer.CreateAngularModule(new AngularModule(EndpointName, metadataReader.EntitySets));
        }
    }
}