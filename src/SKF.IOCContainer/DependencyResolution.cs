using SKF.Domain;
using SKF.Infrastructure.Readers;
using SKF.Infrastructure.Readers.Interfaces;
using System.Collections.Generic;
using AML.Infrastructure.Data.EF;
using Unity;

namespace SKF.IOC ///Inversion of control
{
    /// <summary>
    /// Service Locator
    /// </summary>
    public static class DependencyResolution
    {
        // Factory Pattern 
        public static UnityContainer container { get; private set; }
        private static readonly ISHmockEntities _context; // pass the connection to reader via constructer injection
        public static void ConstructContainerAndRegisterTypes()
        {
            container = new UnityContainer();
            container.RegisterType<IDataReader<IList<DJListRow>>, DJExcelFileReader>();
        }
        /// <summary>
        /// For example purposes.
        /// </summary>
        /// <returns></returns>
        public static IDataReader<IList<DJListRow>> GetDJExcelFileReader()
        {
            var reader = container.Resolve<DJExcelFileReader>();// Resolving using constructor DI.
            return reader;
        }
    }
}
