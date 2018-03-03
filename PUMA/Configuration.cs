/*
 * PUMA - PeterU Metadata API

Copyright (c) 2018 LSPDFR-PeterU, 
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of the copyright holder nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace PUMA
{
    /// <summary>
    /// Holds configuration information for PUMA, such as the directories to search for XML files that hold
    /// the metadata about different Models.
    /// </summary>
    public static class Configuration
    {

        /// <summary>
        /// All directories to search for XML files that hold Model metadata.
        /// </summary>
        public static List<string> Directories = new List<string>
        {
            Directory.GetCurrentDirectory() + @"\Plugins\PUMA\PedModelMeta"
        };

        /// <summary>
        /// Log the specified message to the RPH log with details abvout the calling object and method.
        /// </summary>
        /// <param name="logString">The string to append to the log.</param>
        /// <param name="callingMethod">Do not supply this parameter -- automatically populated with the caller's method name</param>
        public static void Log(string logString, [CallerMemberName]string callingMethod = "")
        {
            StackFrame stackFrame = new StackFrame(1);
            string typeName = stackFrame.GetMethod().DeclaringType.FullName;

            string message = $"{Assembly.GetExecutingAssembly()} (PUMA) {typeName}: {callingMethod}: {logString}";

            Game.LogTrivial(message);
        }

        /// <summary>
        /// Given an Exception, log it appropriately in the RPH log, with an optional friendly explanation.
        /// </summary>
        /// <param name="e">The Exception that has occurred</param>
        /// <param name="explanation">An optional friendly explanation of what occurred/what was being attempted</param>
        /// <param name="callingMethod">Do not supply this parameter -- automatically populated with the caller's method name</param>
        public static void LogException(Exception e, string explanation = "Unable to perform an operation", [CallerMemberName]string callingMethod = "")
        {
            StackFrame stackFrame = new StackFrame(1);
            string typeName = stackFrame.GetMethod().DeclaringType.FullName;
            string logMessage;

            if (e != null)
            {
                logMessage = $"{Assembly.GetExecutingAssembly()} (PUMA) {typeName}: {callingMethod}: {e}";
            }
            else
            {
                logMessage = $"{Assembly.GetExecutingAssembly()} (PUMA) {typeName}: { callingMethod}: {explanation}\r\n[The passed exception was null]";
            }

            Game.LogTrivial(logMessage);
        }


    }
}
