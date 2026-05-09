using RoR2;
using System;
using System.Diagnostics;
using UnityEngine;

namespace PlayerStatsAPI
{
    /// <summary>
    /// A class containing all T.M.I.'s related console commands.
    /// </summary>
    public class CC
    {
        [ConCommand(commandName = "COGetPlayersStat", flags = ConVarFlags.None, helpText = "Retreive any (single) players' stat of any kind. (M.U.T. incompatable but you may use the 'me' shorthand)")]
        public static void CCGetPlayerStat(ConCommandArgs args)
        {
            args.CheckArgumentCount(2);//check if there is at least 2 arguments
            CharacterBody body = null;
            if (args.userArgs[0].ToUpper().Equals("ME"))
            {//if the name is just 'me'
                body = LocalUserManager.GetFirstLocalUser().cachedBody;//return the local player
            }
            else
            {//otherwise get the target body of the player's character
                foreach (NetworkUser user in NetworkUser.readOnlyInstancesList)
                {//for each user
                    if (user.userName.Equals(args.userArgs[0], StringComparison.InvariantCultureIgnoreCase) && user.master.GetBody().isPlayerControlled)
                    {//if the user's username matches the search querey and is a player
                        body = user.GetCurrentBody();//return the players' characterBody
                    }
                }
            }

            if (!body)
            {//if no player found
                MonoBehaviour.print("Could not find the player.");
                return;//end
            }

            string stat = args.userArgs[1];//the stat to retreive
            Type type = null;
            try
            {
                type = Type.GetType(PlayerStats.GetVariableTypeFromString(stat, body), true);//get the type of the stat
            }
            catch (Exception e)
            {
                if (e is ConCommandException)
                {//if the error thrown was caused by the type not existing
                    Trace.TraceError(e.Message.ToString());
                    MonoBehaviour.print(e.Message.ToString());
                    return;
                }
                else
                {
                    Trace.TraceError("An unknown error occured! " + e.Message.ToString());
                    MonoBehaviour.print("An unknown error occured! " + e.Message.ToString());
                    return;
                }
            }

            try
            {
                if (type.Name == "Vector3")
                {
                    IValue<Vector3> playerStats = TMI.PlayerStatsAPIAccessPoint;//example of
                    Vector3 vector = playerStats.GetVariableFromString(stat, body);//longhanded version
                    decimal x = (decimal)vector.x;
                    decimal y = (decimal)vector.y;
                    decimal z = (decimal)vector.z;
                    MonoBehaviour.print(stat + ": " + decimal.Round(x, 2) + ", " + decimal.Round(y, 2) + ", " + decimal.Round(z, 2));
                }
                else if (type.Name == "Color32")
                {
                    Color32 colour = (Color32)PlayerStats.GetVariableObjectFromString(stat, body, typeof(Color32));//example of shorthanded version
                    MonoBehaviour.print(stat + ": Alpha:" + colour.a + ", Red:" + colour.r + ", Green:" + colour.g + ", Blue:" + colour.b);
                }
                else
                {
                    MonoBehaviour.print(stat + ": " + PlayerStats.GetVariableObjectFromString(stat, body));
                }
            }
            catch (Exception e)
            {
                if (e is ConCommandException)
                {
                    Trace.TraceError(e.Message.ToString());
                    MonoBehaviour.print(e.Message.ToString());
                    return;
                }
                else
                {
                    Trace.TraceError("This command cannot get the variables' data at the moment due to an error: " + e.Message.ToString());
                    MonoBehaviour.print("This command cannot get the variables' data at the moment due to an error: " + e.Message.ToString());
                    return;
                }
            }

        }

        [ConCommand(commandName = "COListItems", flags = ConVarFlags.None, helpText = "Lists every item you can pick up in the game")]
        public static void CCCOListItems(ConCommandArgs args)
        {
            //foreach (ItemIndex itemIndex in ItemCatalog.allItems)
            //{
            //    MonoBehaviour.print(itemIndex.ToString());
            //}

            foreach (string item in PlayerStats.GetAllItemsString())
            {
                if (!item.Contains("Count") && !item.Equals(""))
                {
                    MonoBehaviour.print(item);
                }
            }

        }

        [ConCommand(commandName = "COListTiers", flags = ConVarFlags.None, helpText = "Lists items' tiers")]
        private static void CCListTiers(ConCommandArgs args)
        {
            foreach (string tier in PlayerStats.GetAllTiersString())
            {
                if (!tier.Contains("Count"))
                {
                    MonoBehaviour.print(tier);
                }
            }

        }

        [ConCommand(commandName = "COListPlayers", flags = ConVarFlags.None, helpText = "Lists every player in the game")]
        public static void CCCOListPlayers(ConCommandArgs args)
        {
            if (!Stage.instance)
            {
                throw new ConCommandException("This command cannot be used while not in a mission.");
            }
            foreach (NetworkUser user in NetworkUser.readOnlyInstancesList)
            {
                MonoBehaviour.print(user.userName);
            }
        }

        [ConCommand(commandName = "COListEquipment", flags = ConVarFlags.None, helpText = "Lists every equipment item in the game")]
        public static void CCCOListEquipment(ConCommandArgs args)
        {
            foreach (string equipment in PlayerStats.GetAllEquipmentString())
            {
                if (!equipment.Contains("Count") && !equipment.Equals(""))
                {
                    MonoBehaviour.print(equipment);
                }
            }
        }

        [ConCommand(commandName = "COListBuffs", flags = ConVarFlags.None, helpText = "Lists every buff you can get in the game")]
        public static void CCCOListBuffs(ConCommandArgs args)
        {
            foreach (string buff in PlayerStats.GetAllBuffsString())
            {
                if (!buff.Contains("Count") && !buff.Equals(""))
                {
                    MonoBehaviour.print(buff);
                }
            }
        }

        [ConCommand(commandName = "COListTeams", flags = ConVarFlags.None, helpText = "Lists every team currently implemented in the game")]
        public static void CCCOListTeams(ConCommandArgs args)
        {
            foreach (string team in PlayerStats.GetAllTeamsString())
            {
                if (!team.Contains("Count"))
                {
                    MonoBehaviour.print(team);
                }
            }
        }

    }
}
