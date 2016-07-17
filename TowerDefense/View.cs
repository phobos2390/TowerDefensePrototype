using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class View : Form
    {
        private const string rootUrl = "c:\\users\\james\\documents\\visual studio 2015\\Projects\\TowerDefense\\TowerDefense\\";
        private const string grassUrl = /*"c:\\users\\james\\documents\visual studio 2015\\Projects\\TowerDefense\\TowerDefense\\grassTile.png";//*/rootUrl + "grassTile.png";
        private const string villageUrl = /*"c:\\users\\james\\documents\visual studio 2015\\Projects\\TowerDefense\\TowerDefense\\VillageSprites.png";//*/rootUrl + "VillageSprites.png";
        private const string archerUrl = /*"c:\\users\\james\\documents\visual studio 2015\\Projects\\TowerDefense\\TowerDefense\\ArcherSprite.png";//*/rootUrl + "ArcherSprite.png";
        private const string pikemanUrl = rootUrl + "PikemanSprite.png";
        private const string archerWalkUrl = rootUrl + "ArcherWalkCycle.png";
        private Image grass;
        private Image village;
        private Image archer;
        private Image pikeman;
        private Image archerWalkCycle;
        private const int heightOfBoard = 5;
        private const int widthOfBoard = 12;
        private List<Tuple<Point, Image>> placedTowers;
        private List<Image> availableTowers;
        private Image movingImage;
        private Point offset;
        private Timer walkTimer;
        private int archerIndex;
        private int spriteCount;
        private int archerMoveIndex;
        private int movementPerCycle;
        private Point archerLocation;
        private bool archerPlaced;

        public View()
        {
            InitializeComponent();
            grass = Image.FromFile(grassUrl);
            village = Image.FromFile(villageUrl);
            archer = Image.FromFile(archerUrl);
            pikeman = Image.FromFile(pikemanUrl);
            archerWalkCycle = Image.FromFile(archerWalkUrl);
            GameView.ClientSize = new System.Drawing.Size(widthOfBoard * grass.Height, heightOfBoard * grass.Width);
            placedTowers = new List<Tuple<Point, Image>>();
            availableTowers = new List<Image>();
            availableTowers.Add(village);
            availableTowers.Add(archer);
            availableTowers.Add(pikeman);
            walkTimer = new Timer();
            walkTimer.Interval = 125;
            walkTimer.Tick += WalkTimer_Tick;
            walkTimer.Start();
            archerIndex = 0;
            archerMoveIndex = 0;
            spriteCount = 8;
            movementPerCycle = 35;
            archerPlaced = false;
        }

        private void WalkTimer_Tick(object sender, EventArgs e)
        {
            SpriteWindow.Invalidate();
            GameView.Invalidate();
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            int tileHeight = GameView.Height / grass.Height;
            int tileWidth = GameView.Width / grass.Width;
            for(int i = 0; i < tileHeight; ++i)
            {
                for (int j = 0; j < tileWidth; ++j)
                {
                    Point drawPoint = new Point(grass.Width * j, grass.Height * i);
                    e.Graphics.DrawImage(grass,drawPoint);
                }
            }
            foreach(var val in placedTowers)
            {
                image_GameView_Paint(val.Item2, val.Item1.Y, val.Item1.X, e);
            }
            if(archerPlaced)
            {
                e.Graphics.DrawImage(archerWalkCycle,
                    new Rectangle(archerLocation.X, archerLocation.Y, grass.Width, grass.Height),
                    new Rectangle(UnitView_indexToPoint(archerMoveIndex++), new Size(grass.Width, grass.Height)),
                    GraphicsUnit.Pixel);
                if(archerMoveIndex == spriteCount)
                {
                    archerLocation.X += movementPerCycle;
                }
                archerMoveIndex = archerMoveIndex % spriteCount;
            }
        }

        private void image_GameView_Paint(Image image, int row, int col, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Point(col * grass.Width, row * grass.Height));
        }

        private void image_UnitView_Paint(Image image, int index, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, new Point(index * grass.Width, 0));
        }

        private void GameView_MouseMove(object sender, MouseEventArgs e)
        {
            int row = e.Y / grass.Height;
            int col = e.X / grass.Width;
            PositionLabel.Text = "(" + row + "," + col + ")";
        }

        private void UnitView_Paint(object sender, PaintEventArgs e)
        {
            int index = 0;
            foreach(var val in availableTowers)
            {
                image_UnitView_Paint(val, index++, e);
            }
            
        }

        private int UnitView_pointToIndex(Point p)
        {
            return p.X / grass.Width;
        }

        private Point UnitView_indexToPoint(int index)
        {
            return new Point(index * grass.Width, 0);
        }

        private Point UnitView_pointToRowColElement(Point p)
        {
            return new Point(p.X / grass.Width, p.Y / grass.Height);
        }

        private void UnitView_MouseMove(object sender, MouseEventArgs e)
        {
            int index = UnitView_pointToIndex(e.Location);
            PositionLabel.Text = "(" + index + ")";
        }

        private void UnitView_MouseDown(object sender, MouseEventArgs e)
        {
            int index = UnitView_pointToIndex(e.Location);
            if(availableTowers.Count > index)
            {
                movingImage = availableTowers[index];
                pictureBox1.Image = movingImage;
                offset = new Point(e.X % grass.Width, e.Y % grass.Height);
            }
        }

        private bool isOpen(Point elementLocation)
        {
            foreach(var val in placedTowers)
            {
                if(val.Item1.X == elementLocation.X && 
                   val.Item1.Y == elementLocation.Y)
                {
                    return false;
                }
            }
            return true;
        }

        private void GameView_MouseUp(object sender, MouseEventArgs e)
        {
            if(movingImage != null)
            {
                Point position = UnitView_pointToRowColElement(e.Location);
                if(isOpen(position))
                {
                    placedTowers.Add(Tuple.Create(position, movingImage));
                    GameView.Invalidate();
                }
                movingImage = null;
                pictureBox1.Image = null;
            }
            else
            {
                archerLocation = e.Location;
                archerMoveIndex = 0;
                archerPlaced = true;
            }
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            if (movingImage != null)
            {
                e.Graphics.DrawImage(movingImage, new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y));
            }
        }

        private void SpriteWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(archerWalkCycle,
                new Rectangle(0, 0, grass.Width, grass.Height),
                new Rectangle(UnitView_indexToPoint(archerIndex++), new Size(grass.Width, grass.Height)),
                GraphicsUnit.Pixel);
            archerIndex = archerIndex % spriteCount;
        }
    }
}
