using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
    [Flags]
    public  enum enumClass
    {
        none =0,
        read = 1 <<0,
        write =1 <<1,
        excute =1 <<2,
        delete =1<<3,
        admin = read |write |excute |delete
    }

   public static class PermissionExtension
    {

       

        public static bool checkPermissions(this enumClass permissions, enumClass permissionCheck)
        {
            return (permissions & permissionCheck) == permissionCheck;

        }
        public static string permissionsdisPlay(this enumClass permission)
        {
            if (permission == enumClass.none) return "No Permissions";

            List<string> perms = new List<string>();

            if (permission.checkPermissions(enumClass.read)) perms.Add("Read");
            if (permission.checkPermissions(enumClass.write)) perms.Add("Write");
            if (permission.checkPermissions(enumClass.excute)) perms.Add("Execute");
            if (permission.checkPermissions(enumClass.delete)) perms.Add("Delete");

            if (permission.checkPermissions(enumClass.admin)) return "Full Admin Access";

            return "Can " + string.Join(" + ", perms);
        }

    }
}

