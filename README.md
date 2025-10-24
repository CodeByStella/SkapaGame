# Unity TMA - Skateboarding Game

A Unity-based 2D endless runner skateboarding game with Telegram integration, featuring multiple environments, trick systems, and online leaderboards.

## 🎮 Game Overview

**Unity TMA** is an engaging 2D skateboarding endless runner game built with Unity 2022.3.9f1. Players control a skateboarder through various environments, performing tricks, collecting coins, and competing on global leaderboards. The game features seamless Telegram integration for user authentication and data synchronization.

## ✨ Key Features

### 🏃‍♂️ Core Gameplay
- **Endless Runner Mechanics**: Smooth 2D skateboarding with lane-switching and jumping
- **Trick System**: Perform various skateboard tricks including Ollie Flip, Impossible, Method, Nollie, and more
- **Multi-Environment Support**: Three distinct locations - School, Krasnodar, and Las Vegas
- **Progressive Difficulty**: Dynamic obstacle generation and speed increases
- **Coin Collection**: Collect different value coins (1, 2, 3 coins) with smart positioning

### 🎯 Game Mechanics
- **Lane Switching**: Swipe up/down to change lanes (top, middle, bottom)
- **Jumping System**: Single tap for basic jump, double tap for advanced tricks
- **Trick Execution**: Perform tricks on big ramps with combo sequences
- **Lives System**: 3 lives with visual feedback and game over mechanics
- **Tutorial System**: Interactive learning mode for new players

### 🌐 Online Features
- **Telegram Integration**: User authentication via Telegram Bot API
- **Profile Management**: Create and manage user profiles
- **Coin System**: Earn and spend coins with server synchronization
- **Leaderboards**: Global and local score tracking
- **Daily Login Rewards**: Consecutive day tracking and rewards
- **Trick Purchases**: Buy new tricks with earned coins

### 🎨 Customization
- **Character Skins**: Multiple t-shirt designs to choose from
- **Trick Unlocks**: Purchase and unlock new skateboard tricks
- **Visual Feedback**: Animated character with smooth transitions

## 🏗️ Technical Architecture

### Backend Integration
- **REST API**: Custom backend server at `http://45.9.75.242:8080/`
- **User Management**: Profile creation, coin updates, tutorial completion
- **Score System**: Local and global record tracking
- **Trick Management**: Purchase and status updates for tricks
- **Daily System**: Login tracking and reset functionality

### Core Systems
- **MethodsAPIScript**: Main API communication handler
- **TelegramManager**: Telegram integration and user authentication
- **UserData**: User profile data management
- **Money System**: Coin collection and spending mechanics
- **Shop System**: In-game purchases for skins and tricks

## 🎮 Game Controls

### Mobile/Touch Controls
- **Swipe Up**: Move to upper lane
- **Swipe Down**: Move to lower lane
- **Single Tap**: Basic jump
- **Double Tap**: Advanced trick jump
- **Multi-touch**: Enhanced jump mechanics

### Desktop Controls
- **Spacebar**: Jump/Trick execution
- **Mouse Drag**: Lane switching
- **Mouse Click**: Jump activation

## 🌍 Game Environments

### 1. School Level
- **Theme**: Educational campus setting
- **Background**: School buildings and campus environment
- **Difficulty**: Beginner-friendly
- **Special Features**: Learning-focused obstacles

### 2. Krasnodar Level
- **Theme**: Urban city environment
- **Background**: City skyline and urban architecture
- **Difficulty**: Intermediate
- **Special Features**: City-specific obstacles and ramps

### 3. Las Vegas Level
- **Theme**: Casino and entertainment district
- **Background**: Vegas strip and neon lights
- **Difficulty**: Advanced
- **Special Features**: High-speed sections and complex trick opportunities

## 🛠️ Development Setup

### Prerequisites
- Unity 2022.3.9f1 or later
- Visual Studio or compatible IDE
- Git for version control

### Installation
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd "Unity TMA"
   ```

2. Open the project in Unity Editor
3. Ensure all dependencies are imported
4. Configure build settings for your target platform

### Build Configuration
- **WebGL**: Optimized for browser deployment
- **Mobile**: Android/iOS builds supported
- **Desktop**: Windows/Mac/Linux standalone builds

## 📱 Platform Support

### WebGL
- Browser-based gameplay
- Telegram Web App integration
- Optimized for web performance

### Mobile
- Touch controls optimized
- Responsive UI scaling
- Performance optimizations for mobile devices

### Desktop
- Keyboard and mouse support
- Full-screen gameplay
- Enhanced graphics for larger screens

## 🔧 API Endpoints

### Profile Management
- `POST /profile/create` - Create new user profile
- `PUT /profile/update-coins` - Update user coin balance
- `POST /profile/get-coins` - Retrieve current coin balance
- `PUT /profile/tutorial/complete` - Mark tutorial completion

### Records System
- `POST /records/save` - Save player score
- `POST /records/local` - Get local player records
- `POST /records/global` - Get global leaderboard

### Trick System
- `POST /tricks/purchase` - Purchase new trick
- `PUT /tricks/update-status` - Update trick usage status
- `POST /tricks/tricks` - Get user's purchased tricks
- `POST /tricks/tricks/all` - Get all available tricks

### Daily System
- `POST /daily/daily/check` - Check daily login status
- `POST /daily/daily/reset` - Reset daily login counter

## 🎯 Game Progression

### Tutorial System
1. **Basic Movement**: Learn lane switching
2. **Jumping**: Master single and double jumps
3. **Trick Execution**: Perform basic tricks
4. **Score System**: Understand scoring mechanics
5. **Lives System**: Learn about health and consequences

### Progression Mechanics
- **Coin Collection**: Earn coins through gameplay
- **Trick Unlocks**: Purchase new tricks with coins
- **Skin Customization**: Buy and equip different character skins
- **Score Improvement**: Compete on leaderboards

## 🎨 Assets and Resources

### Sprites and Graphics
- **Character Animations**: Smooth skateboarder animations
- **Environment Art**: Unique backgrounds for each level
- **UI Elements**: Modern, responsive interface design
- **Particle Effects**: Visual feedback for tricks and jumps

### Audio
- **Background Music**: Dynamic music system
- **Sound Effects**: Jump, trick, and collection sounds
- **Ambient Audio**: Environment-specific audio

## 🚀 Deployment

### WebGL Deployment
1. Configure WebGL build settings
2. Set up Telegram Web App integration
3. Deploy to web server
4. Configure HTTPS for secure connections

### Mobile Deployment
1. Configure platform-specific settings
2. Optimize for target device specifications
3. Test on various screen sizes
4. Submit to app stores

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is proprietary software. All rights reserved.

## 🆘 Support

For technical support or questions about the game:
- Check the Unity Console for error messages
- Review the API documentation for backend issues
- Test on different platforms and devices

## 🔮 Future Enhancements

- **Multiplayer Mode**: Real-time multiplayer gameplay
- **More Environments**: Additional themed levels
- **Advanced Tricks**: Complex trick combinations
- **Social Features**: Friend systems and challenges
- **Achievement System**: Unlockable achievements and rewards

---

**Unity TMA** - Where skateboarding meets endless adventure! 🛹✨
