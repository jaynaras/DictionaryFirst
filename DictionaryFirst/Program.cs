using System;
using System.Collections.Generic;
using System.Reflection;
using Universal.Common.Collections;

namespace DictionaryFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            MultiDictionary<string, string> multiDictionary = new MultiDictionary<string, string>();

            var mdf = new MultiDictionaryFirst();


            string actions;

            int i = 0;
            while (i < 75)
            {
                Console.WriteLine("> ");
                actions = Console.ReadLine();

                string[] cmdsInputs = actions.Split(' ');

                MethodInfo actionMethod = mdf.GetType().GetMethod(cmdsInputs[0].ToUpper());
                if (actionMethod == null)
                {
                    Console.WriteLine("Enter valid Actions...!");
                    continue;
                }
                object result = actionMethod.Invoke(mdf, new object[] { cmdsInputs, multiDictionary });

                i++;
            }

        }

    }

    public class MultiDictionaryFirst
    {
        public void ADD(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (multiDictionary.ContainsKey(cmdsInputs[1]) && multiDictionary[cmdsInputs[1]].IndexOf(cmdsInputs[2]) >= 0)
            {
                Console.WriteLine(") ERROR, value already exists");
            }
            else
            {
                multiDictionary.Add(cmdsInputs[1], cmdsInputs[2]);
                Console.WriteLine(") Added ");
            }
        }
        public void KEYS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            int j = 0;
            IEnumerable<string> keys = multiDictionary.Keys;
            foreach (string k in keys)
            {
                j++;
                Console.WriteLine("{0}) {1}", j, k);
            }

            if (j == 0)
            {
                Console.WriteLine(") empty set");
            }
        }
        public void MEMBERS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (!multiDictionary.ContainsKey(cmdsInputs[1]))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                return;
            }

            var keyValues = multiDictionary[cmdsInputs[1]];

            int j = 0;
            foreach (string value in keyValues)
            {
                j++;
                Console.WriteLine("{0}) {1}", j, value);
            }
        }
        public void REMOVE(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (!multiDictionary.ContainsKey(cmdsInputs[1]))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                return;
            }

            if (multiDictionary[cmdsInputs[1]].IndexOf(cmdsInputs[2]) < 0)
            {
                Console.WriteLine(") ERROR, value does not exist.");
            }
            else
            {
                
                multiDictionary[cmdsInputs[1]].RemoveAt(multiDictionary[cmdsInputs[1]].IndexOf(cmdsInputs[2]));
                // key has no values, then delete the key too
                if (multiDictionary[cmdsInputs[1]].Count == 0)
                {
                    multiDictionary.Remove(cmdsInputs[1]);
                }
                Console.WriteLine(") Removed ");
            }

        }
        public void REMOVEALL(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (!multiDictionary.ContainsKey(cmdsInputs[1]))
            {
                Console.WriteLine(") ERROR, key does not exist.");
            }
            else
            {
                multiDictionary.Remove(cmdsInputs[1]);
                Console.WriteLine(") Removed");

            }
        }
        public void CLEAR(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            multiDictionary.Clear();
            Console.WriteLine(") Cleared ");
        }
        public void KEYEXISTS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (multiDictionary.ContainsKey(cmdsInputs[1]))
            {
                Console.WriteLine(") true");
            }
            else
            {
                Console.WriteLine(") false");

            }
        }
        public void VALUEEXISTS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            if (!multiDictionary.ContainsKey(cmdsInputs[1]))
            {
                Console.WriteLine(") false");
                return;
            }
            var keyValues = multiDictionary[cmdsInputs[1]];
            if (keyValues.Contains(cmdsInputs[2]))
            {
                Console.WriteLine(") true");
            }
            else
            {
                Console.WriteLine(") false");
            }
        }
        public void ALLMEMBERS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            int j = 0;
            foreach (KeyValuePair<string, string> kvp in multiDictionary)
            {
                j++;
                Console.WriteLine("{0}) {1}", j, kvp.Value);
            }

            if (j == 0)
            {
                Console.WriteLine(") empty set");
            }
        }
        public void ITEMS(string[] cmdsInputs, MultiDictionary<string, string> multiDictionary)
        {
            int j = 0;
            foreach (KeyValuePair<string, string> kvp in multiDictionary)
            {
                j++;
                Console.WriteLine("{0}) {1}: {2}", j, kvp.Key, kvp.Value);
            }

            if (j == 0)
            {
                Console.WriteLine(") empty set");
            }
        }

    }

}
