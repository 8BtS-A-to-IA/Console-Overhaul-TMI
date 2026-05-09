using System;
using System.Diagnostics;
using R2API.Utils;
using RoR2;
using UnityEngine;

namespace PlayerStatsAPI
{
    /// <summary>
    /// A generic interface which provides access to a CharacterBodies data according to the type required.
    /// </summary>
    /// <typeparam name="T">The type which the target statistic is. Supported types are: float, int32, Uint32, Byte, bool, string, UnityEngine.Vector3 and UnityEngine.Color32.
    /// </typeparam>
    public interface IValue<T>
    {
        /// <summary>
        /// Gets the queried <paramref name="stat"/>'s data from the target <paramref name="body"/> and returns the type defined.
        /// </summary>
        /// <example>
        /// Call this method by doing:
        /// <code>
        /// IValue<!--<#Type#>--> playerStats = TMI.PlayerStatsAPIAccessPoint;
        /// comparatorVar = playerStats.GetVariableFromString(stat, body);
        /// </code>
        /// Where #Type# is the type needed.
        /// Alternatively use:
        /// <code>
        /// PlayerStats.GetVariableObjectFromString(stat, body, [type]);
        /// </code>
        /// Where type is optional.
        /// </example> 
        /// <param name="stat">The statistic to target.</param>
        /// <param name="body">The body to get the statistic from.</param>
        /// <returns>Returns the variable according to the Type defined by the object instantiation of this interface.</returns>
        /// <exception cref="ConCommandException">Thrown when the stat could not be found.</exception>
        T GetVariableFromString(string stat, CharacterBody body);
    }

    /// <summary>
    /// A class which provides access to a CharacterBodies information, based on the client's end when possible. This is the T.M.I. system.
    /// </summary>
    public class PlayerStats : IValue<float>, IValue<bool>, IValue<Vector3>, IValue<string>, IValue<Color32>
    {
        /// <summary>
        /// Returns the queried stat's literal type as a string.
        /// </summary>
        /// <param name="stat">The statistic to target.</param>
        /// <param name="body">The body to get the statistic from.</param>
        /// <returns>Statistics type as a string</returns>
        /// <example>
        /// Call this method and get the type literal by doing:
        /// <code>
        /// Type.GetType(PlayerStatsAPIAccessPoint.GetVariableTypeFromString(stat, body))
        /// </code>
        /// </example> 
        /// <exception cref="ConCommandException">Thrown when the stat could not be found.</exception>
        public static string GetVariableTypeFromString(string stat, CharacterBody body)
        {
            try
            {
                IValue<float> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body).GetType().ToString();
            }
            catch (ConCommandException e)
            {
                try
                {
                    if (e.Message.StartsWith("Invalid comparator!"))
                    {
                        IValue<bool> playerStats = TMI.PlayerStatsAPIAccessPoint;
                        return playerStats.GetVariableFromString(stat, body).GetType().ToString();
                    }
                    else { throw new ConCommandException(e.Message); }
                }
                catch (ConCommandException ee)
                {
                    try
                    {
                        if (ee.Message.StartsWith("Invalid comparator!"))
                        {
                            IValue<Vector3> playerStats = TMI.PlayerStatsAPIAccessPoint;
                            return playerStats.GetVariableFromString(stat, body).GetType().ToString();
                        }
                        else { throw new ConCommandException(ee.Message); }
                    }
                    catch (ConCommandException eee)
                    {
                        try
                        {
                            if (eee.Message.StartsWith("Invalid comparator!"))
                            {
                                IValue<string> playerStats = TMI.PlayerStatsAPIAccessPoint;
                                return playerStats.GetVariableFromString(stat, body).GetType().ToString();
                            }
                            else { throw new ConCommandException(eee.Message); }
                        }
                        catch (ConCommandException eeee)
                        {
                            try
                            {
                                if (eeee.Message.StartsWith("Invalid comparator!"))
                                {
                                    IValue<Color32> playerStats = TMI.PlayerStatsAPIAccessPoint;
                                    return playerStats.GetVariableFromString(stat, body).GetType().ToString();
                                }
                                else { throw new ConCommandException(eeee.Message); }
                            }
                            catch (Exception exc)
                            {
                                throw new ConCommandException(exc.Message);
                            }
                        }
                    }
                }
            }
        }

        //Note: float handles: float, int, Uint and byte
        float IValue<float>.GetVariableFromString(string stat, CharacterBody body)
        {
            //float
            if (stat.ToLower() == "acceleration")
            {
                return body.acceleration;
            }
            if (stat.ToLower() == "armor")
            {
                return body.armor;
            }
            if (stat.ToLower() == "attackspeed")
            {
                return body.attackSpeed;
            }
            if (stat.ToLower() == "barrierdecayrate")
            {
                return body.barrierDecayRate;
            }
            if (stat.ToLower() == "bestfitradius")
            {
                return body.bestFitRadius;
            }
            if (stat.ToLower() == "crit")
            {
                return body.crit;
            }
            if (stat.ToLower() == "critheal")
            {
                return body.critHeal;
            }
            if (stat.ToLower() == "cursepenalty")
            {
                return body.cursePenalty;
            }
            if (stat.ToLower() == "damage")
            {
                return body.damage;
            }
            if (stat.ToLower() == "experience")
            {
                return body.experience;
            }
            if (stat.ToLower() == "jumppower")
            {
                return body.jumpPower;
            }
            if (stat.ToLower() == "level")
            {
                return body.level;
            }
            if (stat.ToLower() == "maxbarrier")
            {
                return body.maxBarrier;
            }
            if (stat.ToLower() == "maxhealth")
            {
                return body.maxHealth;
            }
            if (stat.ToLower() == "maxjumpcount")
            {
                return body.maxJumpCount;
            }
            if (stat.ToLower() == "maxjumpheight")
            {
                return body.maxJumpHeight;
            }
            if (stat.ToLower() == "maxshield")
            {
                return body.maxShield;
            }
            if (stat.ToLower() == "movespeed")
            {
                return body.moveSpeed;
            }
            if (stat.ToLower() == "radius")
            {
                return body.radius;
            }
            if (stat.ToLower() == "regen")
            {
                return body.regen;
            }
            if (stat.ToLower() == "baseacceleration")
            {
                return body.baseAcceleration;
            }
            if (stat.ToLower() == "basearmor")
            {
                return body.baseArmor;
            }
            if (stat.ToLower() == "baseattackspeed")
            {
                return body.baseAttackSpeed;
            }
            if (stat.ToLower() == "basecrit")
            {
                return body.baseCrit;
            }
            if (stat.ToLower() == "basedamage")
            {
                return body.baseDamage;
            }
            if (stat.ToLower() == "basejumpcount")
            {
                return body.baseJumpCount;
            }
            if (stat.ToLower() == "basejumppower")
            {
                return body.baseJumpPower;
            }
            if (stat.ToLower() == "basemaxhealth")
            {
                return body.baseMaxHealth;
            }
            if (stat.ToLower() == "basemaxshield")
            {
                return body.baseMaxShield;
            }
            if (stat.ToLower() == "basemovespeed")
            {
                return body.baseMoveSpeed;
            }
            if (stat.ToLower() == "baseregen")
            {
                return body.baseRegen;
            }
            if (stat.ToLower() == "bodyindex")
            {
                return (float)body.bodyIndex;
            }
            if (stat.ToLower() == "killcount")
            {
                return body.killCountServer;
            }
            if (stat.ToLower() == "levelarmor")
            {
                return body.levelArmor;
            }
            if (stat.ToLower() == "levelattackspeed")
            {
                return body.levelAttackSpeed;
            }
            if (stat.ToLower() == "levelcrit")
            {
                return body.levelCrit;
            }
            if (stat.ToLower() == "leveldamage")
            {
                return body.levelDamage;
            }
            if (stat.ToLower() == "leveljumppower")
            {
                return body.levelJumpPower;
            }
            if (stat.ToLower() == "levelmaxhealth")
            {
                return body.levelMaxHealth;
            }
            if (stat.ToLower() == "levelmaxshield")
            {
                return body.levelMaxShield;
            }
            if (stat.ToLower() == "levelmovespeed")
            {
                return body.levelMoveSpeed;
            }
            if (stat.ToLower() == "levelregen")
            {
                return body.levelRegen;
            }
            if (stat.ToLower() == "mainrootspeed")
            {
                return body.mainRootSpeed;
            }
            if (stat.ToLower() == "spreadbloomdecaytime")
            {
                return body.spreadBloomDecayTime;
            }
            if (stat.ToLower() == "combinedhealth")
            {
                return body.healthComponent.combinedHealth;
            }
            if (stat.ToLower() == "combinedhealthfraction")
            {
                return body.healthComponent.combinedHealthFraction;
            }
            if (stat.ToLower() == "fullbarrier")
            {
                return body.healthComponent.fullBarrier;
            }
            if (stat.ToLower() == "fullcombinedhealth")
            {
                return body.healthComponent.fullCombinedHealth;
            }
            if (stat.ToLower() == "fullhealth")
            {
                return body.healthComponent.fullHealth;
            }
            if (stat.ToLower() == "fullshield")
            {
                return body.healthComponent.fullShield;
            }
            if (stat.ToLower() == "timesincelastheal")
            {
                return body.healthComponent.timeSinceLastHeal;
            }
            if (stat.ToLower() == "timesincelasthit")
            {
                return body.healthComponent.timeSinceLastHit;
            }
            if (stat.ToLower() == "potionreserve")
            {
                return body.healthComponent.potionReserve;
            }
            if (stat.ToLower() == "barrier")
            {
                return body.healthComponent.barrier;
            }
            if (stat.ToLower() == "globaldeatheventchancecoefficient")
            {
                return body.healthComponent.globalDeathEventChanceCoefficient;
            }
            if (stat.ToLower() == "health")
            {
                return body.healthComponent.health;
            }
            if (stat.ToLower() == "shield")
            {
                return body.healthComponent.shield;
            }
            if (stat.ToLower() == "currentvehiclesexitvelocityfraction")
            {
                if (body.currentVehicle)
                {
                    return body.currentVehicle.exitVelocityFraction;
                }
            }
            if (stat.ToLower() == "barrierfraction")
            {
                return body.healthComponent.GetHealthBarValues().barrierFraction;
            }
            if (stat.ToLower() == "healthfraction")
            {
                return body.healthComponent.GetHealthBarValues().healthFraction;
            }
            if (stat.ToLower() == "shieldfraction")
            {
                return body.healthComponent.GetHealthBarValues().shieldFraction;
            }
            if (stat.ToLower() == "bodieshurtboxvolume")
            {
                return body.mainHurtBox.volume;//alternative way to search for certain heros/enemies or if someone has disabled their hitbox or if your character does not have a defined hitbox
            }
            if (stat.ToLower() == "charactersyaw")
            {
                return body.characterDirection.yaw;
            }
            if (stat.ToLower() == "charactersturnspeed")
            {
                return body.characterDirection.turnSpeed;
            }
            if (stat.ToLower() == "charactersmaxcamerapitch")
            {
                return body.master.playerCharacterMasterController.cameraMaxPitch;
            }
            if (stat.ToLower() == "charactersmincamerapitch")
            {
                return body.master.playerCharacterMasterController.cameraMinPitch;
            }

            //---------------------------------Vector3.x,y,z--------------------------------------

            if (stat.ToLower() == "aimorigin.x")
            {
                return body.aimOrigin.x;
            }
            if (stat.ToLower() == "aimorigin.y")
            {
                return body.aimOrigin.y;
            }
            if (stat.ToLower() == "aimorigin.z")
            {
                return body.aimOrigin.z;
            }
            if (stat.ToLower() == "coreposition.x")
            {
                return body.corePosition.x;
            }
            if (stat.ToLower() == "coreposition.y")
            {
                return body.corePosition.y;
            }
            if (stat.ToLower() == "coreposition.z")
            {
                return body.corePosition.z;
            }
            if (stat.ToLower() == "footposition.x")
            {
                return body.footPosition.x;
            }
            if (stat.ToLower() == "footposition.y")
            {
                return body.footPosition.y;
            }
            if (stat.ToLower() == "footposition.z")
            {
                return body.footPosition.z;
            }
            if (stat.ToLower() == "charactersanimatorforward.x")
            {
                return body.characterDirection.animatorForward.x;
            }
            if (stat.ToLower() == "charactersanimatorforward.y")
            {
                return body.characterDirection.animatorForward.y;
            }
            if (stat.ToLower() == "charactersanimatorforward.z")
            {
                return body.characterDirection.animatorForward.z;
            }
            if (stat.ToLower() == "charactersforward.x")
            {
                return body.characterDirection.forward.x;
            }
            if (stat.ToLower() == "charactersforward.y")
            {
                return body.characterDirection.forward.y;
            }
            if (stat.ToLower() == "charactersforward.z")
            {
                return body.characterDirection.forward.z;
            }
            if (stat.ToLower() == "charactersmovevector.x")
            {
                return body.characterDirection.moveVector.x;
            }
            if (stat.ToLower() == "charactersmovevector.y")
            {
                return body.characterDirection.moveVector.y;
            }
            if (stat.ToLower() == "charactersmovevector.z")
            {
                return body.characterDirection.moveVector.z;
            }
            if (stat.ToLower() == "characterscrosshairposition.x")
            {
                return body.master.playerCharacterMasterController.crosshairPosition.x;
            }
            if (stat.ToLower() == "characterscrosshairposition.y")
            {
                return body.master.playerCharacterMasterController.crosshairPosition.y;
            }
            if (stat.ToLower() == "characterscrosshairposition.z")
            {
                return body.master.playerCharacterMasterController.crosshairPosition.z;
            }

            //int
            if (stat.ToLower() == "bodieshurtboxbullseyecount")
            {
                int hitboxCount = 0;
                foreach (HurtBox hitbox in body.mainHurtBox.hurtBoxGroup.hurtBoxes)
                {
                    if (hitbox.isBullseye)
                    {
                        hitboxCount++;
                    }
                }
                return hitboxCount;
            }
            if (stat.ToLower() == "bodieshurtboxvolume")
            {
                return body.mainHurtBox.hurtBoxGroup.hurtBoxes.Length;//main way to search if you have defined multiple hitboxes or not
            }
            if (stat.ToLower() == "minioncount")
            {
                return body.master.minionOwnership.group.memberCount;
            }
            if (stat.ToLower().Contains("buffcount"))
            {//if checking a buff's count
                foreach (string buff in GetAllBuffsString())
                {
                    if (stat.ToLower() == "buffcount" + buff.ToLower())
                    {
                        return body.GetBuffCount(BuffCatalog.FindBuffIndex(buff));
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. buffcountblight");
            }
            if (stat.ToLower() == "pendingtonicafflictioncount")
            {
                return body.pendingTonicAfflictionCount;
            }
            if (stat.ToLower() == "multikillcount")
            {
                return body.multiKillCount;
            }
            if (stat.ToLower().Contains("itemcount"))
            {
                foreach (string item in GetAllItemsString())
                {
                    if (stat.ToLower() == "itemcount" + item.ToLower())
                    {
                        return body.inventory.GetItemCount(ItemCatalog.FindItemIndex(item));
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. itemcountmushroom");
            }
            if (stat.ToLower().Contains("itemcountany"))
            {
                return GetAllItemsString().Length;
            }
            if (stat.ToLower().Contains("itemcountoftier"))
            {
                foreach (ItemTier item in (ItemTier[])Enum.GetValues(typeof(ItemTier)))
                {
                    if (stat.ToLower() == "itemcountoftier" + item.ToString().ToLower())
                    {
                        return body.inventory.GetTotalItemCountOfTier(item);
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. itemcountoftiertier1");
            }
            if (stat.ToLower() == "itemcountoftierany")
            {
                int count = 0;
                foreach (ItemTier item in (ItemTier[])Enum.GetValues(typeof(ItemTier)))
                {
                    if (body.inventory.GetTotalItemCountOfTier(item) > 0)
                    {
                        count++;
                    }
                }
                return count;
            }

            //uint
            if (stat.ToLower() == "skinindex")
            {
                return body.skinIndex;
            }
            if (stat.ToLower() == "netid")
            {
                return body.netId.Value;
            }
            if (stat.ToLower() == "healthcomponentnetid")
            {
                return body.healthComponent.netId.Value;//use this for banning?
            }
            if (stat.ToLower() == "skinindex")
            {
                return body.skinIndex;
            }
            //Byte
            if (stat.ToLower() == "userscolour.r")
            {
                return body.master.playerCharacterMasterController.networkUser.userColor.r;
            }
            if (stat.ToLower() == "userscolour.g")
            {
                return body.master.playerCharacterMasterController.networkUser.userColor.g;
            }
            if (stat.ToLower() == "userscolour.b")
            {
                return body.master.playerCharacterMasterController.networkUser.userColor.b;
            }
            if (stat.ToLower() == "userscolour.a")
            {
                return body.master.playerCharacterMasterController.networkUser.userColor.a;
            }
            if (stat.ToLower() == "networkuserscolor.r")
            {
                return body.master.playerCharacterMasterController.networkUser.NetworkuserColor.r;
            }
            if (stat.ToLower() == "networkuserscolor.g")
            {
                return body.master.playerCharacterMasterController.networkUser.NetworkuserColor.g;
            }
            if (stat.ToLower() == "networkuserscolor.b")
            {
                return body.master.playerCharacterMasterController.networkUser.NetworkuserColor.b;
            }
            if (stat.ToLower() == "networkuserscolor.a")
            {
                return body.master.playerCharacterMasterController.networkUser.NetworkuserColor.a;
            }
            if (stat.ToLower() == "mushroomitem.healfraction")
            {
                CharacterBody.MushroomItemBehavior behavior = body.GetComponent<CharacterBody.MushroomItemBehavior>();
                if (behavior)
                {
                    GameObject temp = behavior.GetFieldValue<GameObject>("mushroomWard");
                    if (temp)
                    {
                        HealingWard temp2 = temp.GetComponent<HealingWard>();
                        return temp2.healFraction;
                    }
                    else
                    {
                        throw new ConCommandException("The mushroom items' ward effect has not yet started. (got null mushroomWard)");
                    }
                }
                else
                {
                    throw new ConCommandException("Player does not have the mushroom item. (got null component)");
                }

            }
            if (stat.ToLower() == "mushroomitem.healpoints")
            {
                CharacterBody.MushroomItemBehavior behavior = body.GetComponent<CharacterBody.MushroomItemBehavior>();
                if (behavior)
                {
                    GameObject temp = behavior.GetFieldValue<GameObject>("mushroomWard");
                    if (temp)
                    {
                        HealingWard temp2 = temp.GetComponent<HealingWard>();
                        return temp2.healPoints;
                    }
                    else
                    {
                        MonoBehaviour.print("The mushroom items' ward effect has not yet started. (got null mushroomWard)");
                        return 0f;
                    }
                }
                else
                {
                    MonoBehaviour.print("Player does not have the mushroom item. (got null component)");
                    return 0f;
                }
            }
            if (stat.ToLower() == "mushroomitem.interval")
            {
                CharacterBody.MushroomItemBehavior behavior = body.GetComponent<CharacterBody.MushroomItemBehavior>();
                if (behavior)
                {
                    GameObject temp = behavior.GetFieldValue<GameObject>("mushroomWard");
                    if (temp)
                    {
                        HealingWard temp2 = temp.GetComponent<HealingWard>();
                        return temp2.interval;
                    }
                    else
                    {
                        MonoBehaviour.print("The mushroom items' ward effect has not yet started. (got null mushroomWard)");
                        return 0f;
                    }
                }
                else
                {
                    MonoBehaviour.print("Player does not have the mushroom item. (got null component)");
                    return 0f;
                }
            }
            if (stat.ToLower() == "mushroomitem.radius")
            {
                CharacterBody.MushroomItemBehavior behavior = body.GetComponent<CharacterBody.MushroomItemBehavior>();
                if (behavior)
                {
                    GameObject temp = behavior.GetFieldValue<GameObject>("mushroomWard");
                    if (temp)
                    {
                        HealingWard temp2 = temp.GetComponent<HealingWard>();
                        return temp2.radius;
                    }
                    else
                    {
                        MonoBehaviour.print("The mushroom items' ward effect has not yet started. (got null mushroomWard)");
                        return 0f;
                    }
                }
                else
                {
                    MonoBehaviour.print("Player does not have the mushroom item. (got null component)");
                    return 0f;
                }
            }

            throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
        }

        bool IValue<bool>.GetVariableFromString(string stat, CharacterBody body)
        {
            if (stat.ToLower() == "alive")
            {
                return body.master.IsDeadAndOutOfLivesServer();
            }
            if (stat.ToLower() == "issprinting")
            {
                return body.isSprinting;
            }
            if (stat.ToLower() == "isboss")
            {
                return body.isBoss;
            }
            if (stat.ToLower() == "isclient")
            {
                return body.isClient;
            }
            if (stat.ToLower() == "iselite")
            {
                return body.isElite;
            }
            if (stat.ToLower() == "islocalplayer")
            {
                return body.isLocalPlayer;
            }
            if (stat.ToLower() == "isplayercontrolled")
            {
                return body.isPlayerControlled;
            }
            if (stat.ToLower() == "isserver")
            {
                return body.isServer;
            }
            if (stat.ToLower() == "outofcombat")
            {
                return body.outOfCombat;
            }
            if (stat.ToLower() == "outofdanger")
            {
                return body.outOfDanger;
            }
            if (stat.ToLower() == "shouldaim")
            {
                return body.shouldAim;
            }
            if (stat.ToLower() == "warcryready")
            {
                return body.warCryReady;
            }
            if (stat.ToLower() == "ischampion")
            {
                return body.isChampion;
            }
            if (stat.ToLower() == "hidecrosshair")
            {
                return body.hideCrosshair;
            }
            if (stat.ToLower() == "waslucky")
            {
                return body.wasLucky;
            }
            if (stat.ToLower() == "isnotmoving")
            {
                return body.GetNotMoving();
            }
            if (stat.ToLower() == "hasnobuff")
            {
                bool flag = true;
                foreach (string buff in GetAllBuffsString())
                {
                    if (buff != "None")
                    {
                        if (body.HasBuff(BuffCatalog.FindBuffIndex(buff)))
                        {
                            flag = false;
                        }
                    }
                }
                return flag;
                //return false;
            }
            if (stat.ToLower().Contains("hasbuff"))
            {//check each buff
                foreach (string buff in GetAllBuffsString())
                {
                    if (stat.ToLower() == "hasbuff" + buff.ToString().ToLower())
                    {
                        return body.HasBuff(BuffCatalog.FindBuffIndex(buff));
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. hasbuffblight");
            }
            //int[] tmpout = { };
            //body.inventory.WriteItemStacks(tmpout);
            if (stat.ToLower().Contains("hasitem"))
            {
                foreach (string item in GetAllItemsString())
                {
                    if (stat.ToLower() == "hasitem" + item.ToLower())
                    {
                        return body.inventory.GetItemCount(ItemCatalog.FindItemIndex(item)) > 0;
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. hasitemmushroom");
            }
            if (stat.ToLower().Contains("hasequipment"))
            {
                foreach (string equipment in GetAllEquipmentString())
                {
                    if (stat.ToLower() == "hasequipment" + equipment.ToLower())
                    {
                        return body.inventory.GetEquipmentIndex() == EquipmentCatalog.FindEquipmentIndex(equipment);
                    }
                }
                throw new ConCommandException("Query requires identifier. E.g. hasequipmentsaw");
            }
            if (stat.ToLower().Contains("hasextralifepending"))
            {
                return body.master.IsExtraLifePendingServer();
            }
            if (stat.ToLower().Contains("isready"))
            {
                return body.master.playerStatsComponent.connectionToClient.isReady;//server connecting to client seing player as ready
            }
            if (stat.ToLower().Contains("isconnected"))
            {
                return body.master.playerStatsComponent.connectionToClient.isConnected;
            }
            if (stat.ToLower() == "godmode")
            {
                return body.healthComponent.godMode;
            }
            if (stat.ToLower() == "hidehealthbar")
            {
                return body.healthComponent.dontShowHealthbar;
            }
            if (stat.ToLower() == "hideallycarddisplay")
            {
                return body.teamComponent.hideAllyCardDisplay;
            }
            if (stat.ToLower() == "currentvehicleisejectingoncollision")
            {
                return body.currentVehicle.ejectOnCollision;
            }
            if (stat.ToLower() == "currentvehicleishidingpassenger")
            {
                return body.currentVehicle.hidePassenger;
            }
            if (stat.ToLower() == "currentvehicleshouldshowonscanner")
            {
                return body.currentVehicle.ShouldShowOnScanner();
            }
            if (stat.ToLower() == "bodieshurtboxhasabullseye")
            {//main way to check if your character has any bullseye's properly defined
                foreach (HurtBox hitbox in body.mainHurtBox.hurtBoxGroup.hurtBoxes)
                {
                    if (hitbox.isBullseye)
                    {
                        return true;
                    }
                }
            }
            if (stat.ToLower() == "characterisdrivingfromrootrotation")
            {
                return body.characterDirection.driveFromRootRotation;
            }
            if (stat.ToLower() == "preventinggameover")
            {
                return body.master.preventGameOver;
            }
            if (stat.ToLower() == "spectator")
            {
                return body.master.playerCharacterMasterController.networkUser.cameraRigController.disableSpectating;
            }
            if (stat.ToLower() == "hasbuffany")
            {//or you can just do &!...-hasnobuff...
                bool flag = false;
                foreach (string buff in GetAllBuffsString())
                {
                    if (buff != "None")
                    {
                        if (body.HasBuff(BuffCatalog.FindBuffIndex(buff)))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                return flag;
                //return false;
            }
            if (stat.ToLower() == "mushroomitem.floorward")
            {
                return typeof(CharacterBody.MushroomItemBehavior).GetFieldValue<GameObject>("mushroomWard").GetComponent<HealingWard>().floorWard;
            }
            //has equipment any
            //has item any

            throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
        }

        Vector3 IValue<Vector3>.GetVariableFromString(string stat, CharacterBody body)
        {
            if (stat.ToLower() == "aimorigin")
            {
                return body.aimOrigin;
            }
            if (stat.ToLower() == "coreposition")
            {
                return body.corePosition;
            }
            if (stat.ToLower() == "footposition")
            {
                return body.footPosition;
            }
            if (stat.ToLower() == "charactersanimatorforward")
            {
                return body.characterDirection.animatorForward;
            }
            if (stat.ToLower() == "charactersforward")
            {//main way to check if your character's animator and forward direction are correctly set
                return body.characterDirection.forward;
            }
            if (stat.ToLower() == "charactersmovevector")
            {
                return body.characterDirection.moveVector;
            }
            if (stat.ToLower() == "characterscrosshairposition")
            {
                return body.master.playerCharacterMasterController.crosshairPosition;
            }

            throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
        }

        string IValue<string>.GetVariableFromString(string stat, CharacterBody body)
        {
            if (stat.ToLower() == "teamfromcomponent")
            {//might not be needed
                return body.teamComponent.teamIndex.ToString();
            }
            if (stat.ToLower() == "username")
            {
                return body.GetUserName();
            }
            if (stat.ToLower() == "bodyname")
            {
                return body.name;
            }
            if (stat.ToLower() == "displayname")
            {
                return body.GetDisplayName();
            }
            if (stat.ToLower() == "lasterattacker")
            {
                return body.healthComponent.lastHitAttacker.name;
            }
            if (stat.ToLower() == "killingdamagetype")
            {
                return body.healthComponent.killingDamageType.ToString();
            }
            if (stat.ToLower() == "team")
            {
                return body.master.teamIndex.ToString();
            }
            if (stat.ToLower() == "hascameramode")
            {
                return body.master.playerCharacterMasterController.networkUser.cameraRigController.cameraMode.ToString();
            }
            if (stat.ToLower() == "characterhasname")
            {
                return body.baseNameToken;
            }

            throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
        }

        Color32 IValue<Color32>.GetVariableFromString(string stat, CharacterBody body)
        {
            if (stat.ToLower() == "userscolour")
            {
                return body.master.playerCharacterMasterController.networkUser.userColor;
            }
            if (stat.ToLower() == "networkuserscolor")
            {
                return body.master.playerCharacterMasterController.networkUser.NetworkuserColor;
            }

            throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
        }

        /// <summary>
        /// Returns any of the stats that are supported by the generic interface as an object.
        /// </summary>
        /// <param name="stat">The statistic to target.</param>
        /// <param name="body">The body to get the statistic from.</param>
        /// <param name="type">The type the stat is, if it's already known.</param>
        /// <exception cref="ConCommandException">Thrown when the stat could not be found.</exception>
        public static object GetVariableObjectFromString(string stat, CharacterBody body)
        {
            try
            {
                try
                {
                    IValue<float> playerStats = TMI.PlayerStatsAPIAccessPoint;
                    return playerStats.GetVariableFromString(stat, body);
                }
                catch (ConCommandException)
                {
                    try
                    {
                        IValue<bool> playerStats = TMI.PlayerStatsAPIAccessPoint;
                        return playerStats.GetVariableFromString(stat, body);
                    }
                    catch (ConCommandException)
                    {
                        try
                        {
                            IValue<Vector3> playerStats = TMI.PlayerStatsAPIAccessPoint;
                            return playerStats.GetVariableFromString(stat, body);
                        }
                        catch (ConCommandException)
                        {
                            try
                            {
                                IValue<string> playerStats = TMI.PlayerStatsAPIAccessPoint;
                                return playerStats.GetVariableFromString(stat, body);
                            }
                            catch (ConCommandException)
                            {
                                try
                                {
                                    IValue<Color32> playerStats = TMI.PlayerStatsAPIAccessPoint;
                                    return playerStats.GetVariableFromString(stat, body);
                                }
                                catch
                                {
                                    throw new ConCommandException("Invalid comparator! Please make sure the stat you are trying to target is spelt correctly (case insensitive).");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e is ConCommandException)
                {//if the error thrown was caused by the type not existing
                    throw new ConCommandException(e.Message.ToString());//Stop further execution to safely return the game to a normal state
                }
                else
                {
                    Trace.TraceError("An unknown error occured! The Type was not understood!");
                    Trace.TraceError("Please make sure the sting type matches the actual types' name in Refr.handleSpecialMath AND CC.COGetPlayersStat" +
                        "(use a breakpoint via DNSpy on Client.GetVariableTypeFromString() of the testing type to get the actual name)" +
                        " or make sure the new variables in your IValue<#type#>.GetVariableFromString() method are also present in Client.GetVariableTypeFromString()!");
                    throw new ConCommandException("Command failed due to an error:\n" + e.Message.ToString());//Stop further execution to safely return the game to a normal state
                }
            }

            //throw new ConCommandException("The type was not undertood.");
        }

        [Obsolete("\r\nIf the type is known, for the sake of preformance, it is recommended to use: \"\r\n" +
            "       IValue<#type#> playerStats = TMI.PlayerStatsAPIAccessPoint;\r\n" +
            "       playerStats.GetVariableFromString(stat, body);\r\n" +
            "\" instead if possible, where #type# is the type you're passing in.\r\n" +
            "This method is simply a shorthanded version which will not be removed (this is only a suggestion).")]
        public static object GetVariableObjectFromString(string stat, CharacterBody body, Type type)
        {
            if (type is null)
            {//if type is null
                GetVariableObjectFromString(stat, body);
            }

            //if type is given then this is just being used for shorthanding
            if (type.Name == "Single" || type.Name == "Int32" || type.Name == "UInt32" || type.Name == "Byte")
            {
                IValue<float> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body);

            }
            else if (type.Name == "Boolean")
            {
                IValue<bool> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body);

            }
            else if (type.Name == "Vector3")
            {
                IValue<Vector3> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body);

            }
            else if (type.Name == "String")
            {
                IValue<string> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body);

            }
            else if (type.Name == "Color32")
            {
                IValue<Color32> playerStats = TMI.PlayerStatsAPIAccessPoint;
                return playerStats.GetVariableFromString(stat, body);

            }



            throw new ConCommandException("The type was not undertood.");
        }

        public static string[] GetAllItemsString() 
        {
            string[] items = new string[ItemCatalog.itemCount];

            for (int i = 0; i < ItemCatalog.itemCount; i++)
            {//foreach item
                items[i] = ItemCatalog.GetItemDef((ItemIndex)i).nameToken.Replace("EQUIPMENT_", "").Replace("_NAME", "");
            }

            return items;
        }

        public static string[] GetAllBuffsString()
        {
            string[] buffs = new string[BuffCatalog.buffCount];

            for (int i = 0; i < BuffCatalog.buffCount; i++)
            {//foreach buff
                buffs[i] = BuffCatalog.GetBuffDef((BuffIndex)i).ToString().Replace(" (RoR2.BuffDef)", "");
            }

            return buffs;
        }

        public static string[] GetAllEquipmentString()
        {
            string[] equipment = new string[EquipmentCatalog.equipmentCount];

            for (int i = 0; i < EquipmentCatalog.equipmentCount; i++)
            {//foreach equipment
                equipment[i] = EquipmentCatalog.GetEquipmentDef((EquipmentIndex)i).nameToken.Replace("EQUIPMENT_", "").Replace("_NAME", "");
            }

            return equipment;
        }

        public static string[] GetAllTiersString()
        {
            ItemTier[] tiers = (ItemTier[])Enum.GetValues(typeof(ItemTier));
            string[] tier = new string[tiers.Length];

            for (int i = 0; i < tiers.Length; i++)
            {//for each tier
                tier[i] = tiers[i].ToString();
            }

            return tier;
        }

        public static string[] GetAllTeamsString()
        {
            TeamIndex[] teamIndecies = (TeamIndex[])Enum.GetValues(typeof(TeamIndex));
            string[] teams = new string[teamIndecies.Length];
            for (int i = 0; i < teamIndecies.Length - 1; i++)
            {//foreach TeamIndex
                teams[i] = teamIndecies[i].ToString();
            }

            return teams;
        }

    }
}
