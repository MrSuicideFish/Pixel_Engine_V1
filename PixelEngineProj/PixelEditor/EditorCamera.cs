using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using PixelEngine;

namespace PixelEditor {
    /// <summary>
    /// The editor camera is the main go-to point for extending and modifying the editor viewport.
    /// NOTE: EditorCamera is simply the viewport matrix handler scene, to access the scene manager itself, please
    /// refer to the pScene class.
    /// </summary>
    public class EditorCamera : PixelEngine.Gameplay.pCamera {
        public float cameraSpeed = 200;
        public int turbo = 1;
        private static int zoomState = 0;

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private bool bMoving = false;
        private List<EditorActor> SelectedActors;
        RectangleShape selectionBox = new RectangleShape(new Vector2f(0, 0));
        RectangleShape[] selectionRects;
        Vector2i initMousePos;
        Vector2i curMousePos;
        Vector2f initCenter;

        public EditorCamera(FloatRect viewRect) : base(viewRect) {
            SelectedActors = new List<EditorActor>();
            selectionRects = new RectangleShape[0];

            //Selection box
            selectionBox.FillColor = new Color(220, 220, 220, 40);
            selectionBox.OutlineThickness = 2;
            selectionBox.OutlineColor = Color.White;
        }

        /// <summary>
        /// Update Call
        /// </summary>
        public void Update() {
            turbo = !SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? 1 : 3;
            if (SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)) {
                if (!bMoving) {
                    //Get the initial mouse world position
                    initMousePos = Form1.mouseScreenPos;
                    initCenter = Center;
                    bMoving = true;
                } else {
                    //Get the current mouse world position
                    curMousePos = Form1.mouseScreenPos;
                }
                //add the difference to the camera world position
                Vector2f newPos = new Vector2f(curMousePos.X, curMousePos.Y) - new Vector2f(initMousePos.X, initMousePos.Y);
                Center = initCenter + -newPos;
            } else if (!SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)) {
                bMoving = false;
            }

            //For now, camera handles input
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.W)) {
                Move(new Vector2f(0, (float)(-cameraSpeed * turbo * Editor.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.S)) {
                Move(new Vector2f(0, (float)(cameraSpeed * turbo * Editor.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.A)) {
                Move(new Vector2f((float)(-cameraSpeed * turbo * Editor.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.D)) {
                Move(new Vector2f((float)(cameraSpeed * turbo * Editor.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.R)) {
                Rotate((float)(0.05f * turbo));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.Q)) {
                Rotate((float)(-0.05f * turbo));
            }

            if (EditorInput.Ctrl == 1 && Mouse.IsButtonPressed(Mouse.Button.Left)) {
                //Begin drag start
                DragSelectionboxStartCallback();
                DragSelectionboxCallback();
            }
            if (EditorInput.Ctrl == 0 || !Mouse.IsButtonPressed(Mouse.Button.Left)) {
                if (bDragging) {
                    DragSelectionboxEndCallback();
                    bDragging = false;
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            if (bDragging) {
                Vector2f _sizeOffset = curMouseRectPos - initMouseRectPos;
                selectionBox.Size = _sizeOffset;
                selectionBox.Draw(target, states);
            }
            foreach (RectangleShape _r in selectionRects) {
                if (_r != null) {
                    _r.Draw(target, states);
                }
            }
        }

        bool bDragging = false;
        FloatRect selectionRect = new FloatRect(0, 0, 0, 0);
        SFML.Window.Vector2f initMouseRectPos, curMouseRectPos;
        void DragSelectionboxStartCallback() {
            if (!bDragging) {
                bDragging = true;
                //Define the start rect
                selectionRect = new FloatRect(0, 0, 0, 0);

                //Set the start location
                initMouseRectPos = Form1.mouseWorldPos;
                selectionBox.Position = initMouseRectPos;
            }
        }

        void DragSelectionboxCallback() {
            curMouseRectPos = Form1.mouseWorldPos;
        }

        void DragSelectionboxEndCallback() {
            //Clear the selected actors
            SelectedActors.Clear();
            foreach (EditorActor _a in EditorScene.SCENE_ACTORS) {
                //Check the object's position
                if (selectionBox.GetGlobalBounds().Contains(
                    _a.actorSprite.GetGlobalBounds().Left + (_a.actorSprite.GetGlobalBounds().Width/2),
                    _a.actorSprite.GetGlobalBounds().Top + (_a.actorSprite.GetGlobalBounds().Height / 2)
                    )) {

                    SelectedActors.Add(_a);
                }
            }
            bDragging = false;
            HighlightSelectedActors();
        }

        void HighlightSelectedActors() {
            //Highlight the selected actors
            selectionRects = new RectangleShape[SelectedActors.Count];
            for (int i = 0; i < selectionRects.Length; i++) {
                //Add the actor to the selectionRects
                selectionRects[i] = new RectangleShape(new Vector2f(
                    SelectedActors[i].GetBoundingBox().Width,
                    SelectedActors[i].GetBoundingBox().Height
                    ));
                selectionRects[i].Position = SelectedActors[i].position;
                selectionRects[i].FillColor = new Color(0, 0, 0, 0);
                selectionRects[i].OutlineColor = Color.Cyan;
                selectionRects[i].OutlineThickness = 1.5f;
            }
        }

        public bool isMoving() {
            return bMoving;
        }

        /// <summary>
        /// Handle camera zooming
        /// </summary>
        /// <param name="factor"></param>
        public void SetZoomState(float factor) {
            if (zoomState == -6 && factor == 0.9f) {
                zoomState++;
            }
            if (zoomState == 6 && factor == 1.1f) {
                zoomState--;
            }
            if (zoomState >= -5 && zoomState <= 5) {
                Zoom(factor);
                zoomState = (factor > 1.0) ? zoomState - 1 : zoomState + 1;
            }
            return;
        }

        public void OnMouseClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && EditorInput.bModifier == 0) {
                foreach (EditorActor _a in EditorScene.SCENE_ACTORS) {
                    if (_a.actorSprite.GetGlobalBounds().Contains(Form1.mouseWorldPos.X, Form1.mouseWorldPos.Y)) {
                        ClearSelectedActors();
                        SelectedActors.Add(_a);
                        HighlightSelectedActors();
                    }
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left && EditorInput.Alt == 1 && EditorInput.Ctrl == 0) {
                EditorActor _newActor = new EditorActor("Test Actor", Form1.mouseWorldPos);
                Editor.SCENE.AddActorToScene(ref _newActor);
            }
        }

        public void OnMouseScroll(object sender, System.Windows.Forms.MouseEventArgs e) {
            float _z = 1 - (float)(e.Delta / 120) / 10;
            SetZoomState(_z);
            Console.WriteLine("scrol");
        }

        public void ClearSelectedActors() {
            if (SelectedActors != null) {
                SelectedActors.Clear();
                for(int i = 0; i < selectionRects.Length; i++){
                    selectionRects[i] = null;
                    GC.Collect();
                }
            }
        }
    }
}
