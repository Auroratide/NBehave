using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Auroratide.NBehave {
    
    public static class Arg {

        public static T Is<T>(T obj) {
            return obj;
        }

        public static ListType Contains<ListType, ObjType>(ObjType obj)
            where ListType : IEnumerable<ObjType> {
            return default(ListType);
        }

        public static T Null<T>() {
            return default(T);
        }

        public static T Any<T>() {
            return default(T);
        }

        public static T That<T>(Predicate<T> predicate) {
            return default(T);
        }

        public static string Pattern(string pattern) {
            return "";
        }

        public static T Not<T>(T matcher) {
            return matcher;
        }

        public static T Matches<T>(Core.Matcher matcher) {
            return default(T);
        }

    }

}