using Godot;
using System;
using System.Text.Encodings.Web;

public partial class player : CharacterBody3D
{
    const float speed = 5f;
    const float gravity = 30f;
    const float jumpForce = 10f;
    const float acceleration = 0.5f;
    const float sensitivity = 0.001f;
    const float sprinte = 10f;
    const float valeurSprint = 10f;
    const float valeurRecupSprint = 2.5f;
    const float valeurRecupSrpintStop = 4f;
    const float ralentir = 2.5f;
    const float valeurLumiereBarAll = 8f;
    const float valeurLumiereBarEteint = 5f;
    bool lampetorcheAllumer = false;
    bool paused = false;
    

    public Node3D head;
    public Camera3D cam; 
    public AnimationPlayer anim;
    public ProgressBar sprintBar;
    public Node3D lampeTorche;
    public SpotLight3D lumiere;
    public ProgressBar lumiereBar;
    public Control menu; 

    private Vector3 velocity = Vector3.Zero;
    
    public override void _Ready()
    {  
        head = GetNode<Node3D>("Head");
        cam = GetNode<Camera3D>("Head/Camera3D");
        anim = GetNode<AnimationPlayer>("Head/epee/frapper");
        sprintBar = GetNode<ProgressBar>("Head/HUD/SprintBar");
        lampeTorche = GetNode<Node3D>("Head/Camera3D/lampeTorche");
        lumiere = GetNode<SpotLight3D>("Head/Camera3D/lampeTorche/lumiere");
        lumiereBar = GetNode<ProgressBar>("Head/HUD/lumiereBar");
        menu = GetNode<Control>("Head/menu");

        menu.Hide();

        Input.MouseMode = Input.MouseModeEnum.Captured;
        lumiere.Hide();
    }

    public override void _Input(InputEvent @event)
    {
       
        if (paused) //si le jeu est en pause
        {
            return; 
            // Ne traitez pas les entrées 
        }

       
        if(@event is InputEventMouseMotion)
        {
            /*
            Ce code contrôle le mouvement de la caméra en réponse aux mouvements 
            de la souris,en ajustant la rotation horizontale de la tête et la rotation 
            verticale de la caméra. Il limite également la rotation verticale de la 
            caméra pour éviter des angles de vue excessifs.
            */
            InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
            head.RotateY(-mouseMotion.Relative.X * sensitivity);
            cam.RotateX(-mouseMotion.Relative.Y * sensitivity);

            Vector3 cameraRot = cam.Rotation;
            cameraRot.X = Mathf.Clamp(cameraRot.X, Mathf.DegToRad(-80f), Mathf.DegToRad(80f));
            cam.Rotation = cameraRot;
        }
    }
    
    public override void _Process(double delta)
    {
//__________________________________________________________________________________________________________________________________
                                                    //Menu
        if(Input.IsActionJustPressed("echap"))
        {
            PauseMenu();
        }
    }
    public void PauseMenu()
    {
        if(paused)
        {
            Input.MouseMode = Input.MouseModeEnum.Captured;
            menu.Hide();
            Engine.TimeScale = 1;
        }
        else
        {
            menu.Show();
            Input.MouseMode = Input.MouseModeEnum.Visible;
            Engine.TimeScale = 0;
        }
        paused = !paused; 
    }
    
//__________________________________________________________________________________________________________________________________

    public override void _PhysicsProcess(double delta)
    {
        if (paused) //si le jeu est en pause
        {
            return; 
            // Ne traitez pas les entrées 
        }
//__________________________________________________________________________________________________________________________________
                                                    //Mouvement
                                                                                                                
        Vector2 inputDir = Input.GetVector("left", "right", "up", "down");
        Vector3 direction = (head.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

        if(direction != Vector3.Zero)
        {
            //permet d'avancer
            velocity.X = direction.X * speed;
            velocity.Z = direction.Z * speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, acceleration);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, acceleration);
            /*
            Ce code ralentit l'objet en diminuant graduellement sa 
            vélocité vers 0 dans les directions X et Z en utilisant 
            une accélération donnée.
            */ 
        }
//__________________________________________________________________________________________________________________________________
                                                    //lampe torche
        
        if (Input.IsActionJustPressed("action"))
        {
            //allumer la lumiere
            lampetorcheAllumer = !lampetorcheAllumer;
            if(lampetorcheAllumer == true)
            {
                lumiere.Show();
            }
            else if (lampetorcheAllumer == false)
            {
                lumiere.Hide();
            }
            //anim.Play("frapper"); 
        }
        if (lampetorcheAllumer == true)
        {
            //si la lampe torche est allumé alors sont pourventage de batterie diminue
            lumiereBar.Value -= valeurLumiereBarAll * delta;
        }
        if(lumiereBar.Value == 0)
        {
            //si la lampe torche n'a plus de batterie alors elle s'éteind
            lampetorcheAllumer = false;
            lumiere.Hide();
        }

        if (lampetorcheAllumer == false)
        {
            //si la lampe torche est éteinte alors sont pourventage de batterie augmente
            lumiereBar.Value += valeurLumiereBarEteint * delta;
        }
//__________________________________________________________________________________________________________________________________
                                                    //sprint
        
        if (Input.IsActionPressed("sprint"))
        {
            //permet de sprinter
            velocity.X = direction.X * sprinte;
            velocity.Z = direction.Z * sprinte;
        }

        if (Input.IsActionPressed("sprint")) 
        {
            // Réduisez la valeur de la ProgressBar lorsque le joueur sprinte.
            sprintBar.Value -= valeurSprint * delta; // Assurez-vous de définir sprintConsumptionRate selon vos besoins.
            if(sprintBar.Value == 0)
            {
                //si la sprintbar est à 0 alors la vitesse revien à celle de départ
                velocity.X = direction.X * speed; 
                velocity.Z = direction.Z * speed;
            }
        }
        else if (direction == Vector3.Zero)
        {
            //si on ne bouge pas la sprintbar augmente
            sprintBar.Value += valeurRecupSrpintStop * delta; 
        }
        else if(direction != Vector3.Zero)
        {
            // si on bouge la sprintbar se recharge
            sprintBar.Value += valeurRecupSprint * delta;
        }
//__________________________________________________________________________________________________________________________________

        if(Input.IsActionPressed("ralentir"))
        {
            //avancer lentement 
            velocity.X = direction.X * ralentir; 
            velocity.Z = direction.Z * ralentir;
        }
        
        

        if(!IsOnFloor() || IsOnCeiling()) // permet de faire tomber l'objet quand il est en l'air
        {
            velocity.Y -= gravity * (float)delta;
        } 
        
        if(IsOnFloor() && Input.IsActionJustPressed("jump")) // permet de sauter
        {
            velocity.Y = jumpForce;
        }
  
        Velocity = velocity;
        MoveAndSlide();
    }
    
}


