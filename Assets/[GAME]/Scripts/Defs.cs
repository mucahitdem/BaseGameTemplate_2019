namespace Scripts
{
    public static class Defs
    {
        #region Pool

        public static readonly string COIN_POOL_ID = "CoinPool";

        #endregion

        #region Define Symbols

        public static readonly string DEFINE_SYMBOLS_ENABLE_LOG = "ENABLE_LOG";

        #endregion

        #region Save Keys

        public static readonly string SAVE_KEY_SCENE_LOADER_TOOL = "Additive";

        public static readonly string SAVE_KEY_COIN_COUNT = "TotalCoinCount";

        public static readonly string SAVE_KEY_LEVEL = "Level";
        public static readonly string SAVE_KEY_FAKE_LEVEL = "FakeLevel";

        public static readonly string SAVE_KEY_PLAYER_LEVEL = "PlayerLevel";
        public static readonly string SAVE_KEY_PLAYER_XP = "PlayerXp";
        public static readonly string SAVE_KEY_PLAYER_HEALTH = "PlayerHealth";
        public static readonly string SAVE_KEY_PLAYER_SPEED = "PlayerSpeed";
        public static readonly string SAVE_KEY_PLAYER_DAMAGE = "PlayerDamage";

        public static readonly string SAVE_KEY_IS_TUTORIAL_PLAYED = "TutorialPlayed";

        public static readonly string SAVE_KEY_IS_TURRET_UNLOCKED = "TurretUnlocked";


        public static readonly string SAVE_KEY_EQUIPPED_WEAPON = "EquippedWeapon";

        public static readonly string SAVE_KEY_CURRENT_ENEMY_SPAWN_INDEX = "CurrentEnemySpawnIndex";

        public static readonly string SAVE_KEY_DONKEY_ACTIVATED = "DonkeyActivated";
        public static readonly string SAVE_KEY_DUCK_ACTIVATED = "DuckActivated";
        public static readonly string SAVE_KEY_DONKEY_PURCHASED = "DonkeyPURCHASED";
        public static readonly string SAVE_KEY_DUCK_PURCHASED = "DuckPURCHASED";

        public static readonly string SAVE_KEY_BG_VOLUME_MULTIPLIER = "BgMultiplier";
        public static readonly string SAVE_KEY_GLOBAL_VOLUME = "GlobalVolume";
        public static readonly string SAVE_KEY_IS_EFFECTS_DISABLED = "IsEffectsDisabled";


        #region Upgrade Data

        public static readonly string SAVE_KEY_INCOME_UPGRADE_COUNT = "IncomeUpgradeCount";
        public static readonly string SAVE_KEY_ADD_UPGRADE_COUNT = "AddUpgradeCount";

        #endregion

        #endregion

        #region Ui Item

        public static readonly string UI_KEY_NOT_IMPLEMENTED = "NOT_IMPLEMENTED";

        public static readonly string UI_KEY_GAME_TIMER = "GameTimer";


        public static readonly string UI_KEY_START_SCREEN = "StartScreen";
        public static readonly string UI_KEY_GENERIC_SCREEN = "GenericScreen";
        public static readonly string UI_KEY_GAME_PLAY_SCREEN = "GamePlayScreen";
        public static readonly string UI_KEY_WIN_SCREEN = "WinScreen";
        public static readonly string UI_KEY_FAIL_SCREEN = "LoseScreen";

        #region Main Panel Uis

        public static readonly string UI_KEY_SHOP_MANAGER = "ShopManagerUi";
        public static readonly string UI_KEY_BATTLE_MANAGER = "BattleManagerUi";
        public static readonly string UI_KEY_WEAPON_MANAGER = "WeaponManagerUi";


        public static readonly string UI_KEY_WEAPON_SPECS = "WeaponSpecs";
        public static readonly string UI_KEY_WEAPON_STATS_MANAGER = "WeaponStatsManager";
        public static readonly string UI_KEY_WEAPON_RANK_UP_PANEL = "WeaponRankUpPanel";
        public static readonly string UI_KEY_WEAPON_RANK_UP_SUCCESSFUL_PANEL = "WeaponRankUpSuccessfulPanel";

        public static readonly string UI_KEY_SKILL_UPGRADE_PANEL = "SkillUpgradePanel";
        public static readonly string UI_KEY_LOADING_SCREEN = "LoadingScreen";
        public static readonly string UI_KEY_LEVEL_SUCCESS_PANEL = "SuccessPanel";
        public static readonly string UI_KEY_LEVEL_FAILED_PANEL = "FailPanel";

        public static readonly string UI_KEY_FLOATING_JOYSTICK = "FloatingJoystick";

        #endregion

        #endregion

        #region Animator Keys

        public static readonly string ANIM_KEY_RIDE = "ride";
        public static readonly string ANIM_KEY_RIDE_IDLE = "rideIdle";

        public static readonly string ANIM_KEY_WALK = "walk";
        public static readonly string ANIM_KEY_WALK_SPEED = "walkSpeed";
        public static readonly string ANIM_KEY_SHOOT = "shoot";

        public static readonly string ANIM_KEY_ATTACK = "attack";
        public static readonly string ANIM_KEY_DIE = "die";
        public static readonly string ANIM_KEY_HIT = "hit";

        #endregion

        #region Tags

        public static readonly string TAG_GROUND = "Ground";
        public static readonly string TAG_XP_SPHERE = "XpSphere";
        public static readonly string TAG_ENEMY = "Enemy";

        #endregion

        #region Layers

        public static readonly string LAYER_XP_SPHERE = "XpSphere";

        public static readonly string LAYER_GROUND = "Ground";
        public static readonly string LAYER_WALL = "Wall";
        public static readonly string LAYER_INTERACT_WTIH_NOTHING = "InteractWithNothing";
        public static readonly string LAYER_NOT_INTERACT_WITH_ENEMY = "NotInteractWithEnemy";
        public static readonly string LAYER_PLAYER = "Player";

        #endregion

        #region Scenes

        public static readonly string SCENE_NAME_LOADER = "Loader";
        public static readonly string SCENE_NAME_LEVEL_MAIN = "LevelMain";
        public static readonly string SCENE_NAME_LEVEL_1 = "Level1";

        #endregion

        #region Static So Keys

        public static readonly string STATIC_SO_KEY_ALL_GAME_STATES = "AllGameStateDataSo";
        public static readonly string STATIC_SO_KEY_ALL_ENEMIES = "AllEnemies";

        #endregion

        #region Game State Ids

        public static readonly string GAME_STATE_START = "GameStateStart";
        public static readonly string GAME_STATE_PLAYING = "GameStatePlaying";
        public static readonly string GAME_STATE_LOSE = "GameStateLose";
        public static readonly string GAME_STATE_WIN = "GameStateWin";

        #endregion

        #region AUDIO IDS

        public static readonly string AUDIO_LEVEL_UP = "levelUp";
        public static readonly string AUDIO_LASER_SHOT = "laserShot";
        public static readonly string AUDIO_MINER_SET_UP = "minerSetUp";
        public static readonly string AUDIO_WIN_BATTLE = "winBattle";
        public static readonly string AUDIO_PLAYER_DEATH = "playerDeath";
        public static readonly string AUDIO_DAILY_REWARDS = "dailyRewards";
        public static readonly string AUDIO_BUTTON_CLICK = "buttonClick";
        public static readonly string AUDIO_WARNING = "warning";
        public static readonly string AUDIO_EARN = "earn";
        public static readonly string AUDIO_EARN_MONEY = "earnMoney";
        public static readonly string AUDIO_ENEMY_MELEE_ATTACK = "enemyMeleeAttack";
        public static readonly string AUDIO_RAIDER_ATTACK = "raiderAttack";
        public static readonly string AUDIO_ROCKET = "rocket";
        public static readonly string AUDIO_SELL_RESOURCES = "SellResources";
        public static readonly string AUDIO_COLLECT_RESOURCES = "CollectResources";
        public static readonly string AUDIO_DUCK = "duckSound";
        public static readonly string AUDIO_DONKEY = "donkeySound";

        #endregion
    }
}