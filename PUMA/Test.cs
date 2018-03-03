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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

[assembly: Rage.Attributes.Plugin("PUMA", Description ="Test environment for PedModelMetaAPI", EntryPoint ="PUMA.Test.Main", Author = "PeterU")]
namespace PUMA
{
    /// <summary>
    /// A test environment for PUMA to create peds and describe them.
    /// </summary>
    public static class Test
    {

        /// <summary>
        /// Test environment.
        /// </summary>
        public static void Main()
        {
            PedModels.BuildLookupDictionary();
            while (true)
            {
                
                foreach(KeyValuePair<string, PedModelMeta> modelMeta in PedModels.PedModelMetaLookup)
                {
                    Ped demoPed = new Ped(modelMeta.Key, Game.LocalPlayer.Character.GetOffsetPositionFront(1.5f), 0f);
                    demoPed.Face(Game.LocalPlayer.Character);

                    Game.DisplayNotification($"{demoPed.Model.Name}: {PedModels.GetTextDescription(demoPed, PedDescriptionPropertyType.Build | PedDescriptionPropertyType.Clothing | PedDescriptionPropertyType.Extras | PedDescriptionPropertyType.Hair | PedDescriptionPropertyType.RaceSex)}");


                    GameFiber.Sleep(8000);


                    if (demoPed)
                    {
                        demoPed.Delete();
                    }

                }

                GameFiber.Yield();
            }
        }

    }
}
