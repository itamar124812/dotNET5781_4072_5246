using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace DalApi
{
    class DalFactory
    {
        public static IDal GetDL()
        {
            string dlType = DLConfig.DLName;
            DLConfig.DLPackage dlPackage;
            try 
            {
                dlPackage = DLConfig.DLPackages[dlType];
            }
            catch (KeyNotFoundException ex)
            {
                throw new DLConfigException($"Wrong DL type: {dlType}", ex);
            }
            string dlPackageName = dlPackage.PkgName;
            string dlNameSpace = dlPackage.NameSpace;
            string dlClass = dlPackage.ClassName;

            try // Load into CLR the dal implementation assembly according to dll file name (taken above)
            {
                Assembly.Load(dlPackageName);
            }
            catch (Exception ex)
            {
                throw new DLConfigException($"Failed loading {dlPackageName}.dll", ex);
            }
            Type type;
            try
            {
                type = Type.GetType($"{dlNameSpace}.{dlClass}, {dlPackageName}", true);
            }
            catch (Exception ex)
            { // If the type is not found - the implementation is not correct - it looks like the class name is wrong...
                throw new DLConfigException($"Class not found due to a wrong namespace or/and class name: {dlPackageName}:{dlNameSpace}.{dlClass}", ex);
            }
            try
            {
                IDal dal = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null) as IDal;
                // If the instance property is not initialized (i.e. it does not hold a real instance reference)...
                if (dal == null)
                    throw new DLConfigException($"Class {dlNameSpace}.{dlClass} instance is not initialized");
                // now it looks like we have appropriate dal implementation instance :-)
                return dal;
            }
            catch (NullReferenceException ex)
            {
                throw new DLConfigException($"Class {dlNameSpace}.{dlClass} is not a singleton", ex);
            }

        }
    }
}
