using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;


[Spawnable]
[Library( "ent_shiproot", Title = "Ship Root" )]
public partial class ShipRoot : Prop, IUse
{
	public bool IsUsable( Entity user )
	{
		return true;
	}

	public bool OnUse( Entity user )
	{
		var vertices = Model.GetVertices();

		return false;
	}

	public override void Spawn()
	{
		base.Spawn();
		SetModel( "models/spacebox/cube.vmdl" );
		CloneModel(Model);
	}

	public void CloneModel( Model model)
	{
		Model = BuildModel(model.GetVertices(), model.GetIndices());
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic );
		EnableAllCollisions = true;
	}
	public Model BuildModel( Vertex[] vertices, uint[] indices )
	{
		var mesh = BuildMesh( vertices, indices);
		var model = Model.Builder
			.AddMesh( mesh )
			.Create();
		return model;
	}
	public Mesh BuildMesh( Vertex[] verts, uint[] indices )
	{
		var mesh = new Mesh( Material.Load( "materials/generic/metal_brushed.vmat" ) );
		var vb = new VertexBuffer();
		for(var i = 0; i<indices.Length; i+=3 )
		{
			vb.AddTriangle( verts[indices[i]], verts[indices[i+1]], verts[indices[i+2]] );
			//vb.AddTriangleIndex( (int)indices[i], (int)indices[i + 1], (int)indices[i + 2] );
		}
		mesh.CreateBuffers( vb );
		var indicesint = new List<int>();
		foreach ( var indice in indices ) indicesint.Add( (int)indice );
		//mesh.CreateIndexBuffer( indices.Length, indicesint );
		return mesh;
	}
}
