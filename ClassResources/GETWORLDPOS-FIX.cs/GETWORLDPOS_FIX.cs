	//The math in World.cs for the GetWorldBlock in the video breaks down around the world locations
	//of -16 and this is because of the way the Mathf.Round works with negative numbers.
    //here is a fix.


	public static Block GetWorldBlock(Vector3 pos)
	{
		int cx, cy, cz;
		
		if(pos.x < 0)
			cx = (int) ((Mathf.Round(pos.x-chunkSize)+1)/(float)chunkSize) * chunkSize;
		else
			cx = (int) (Mathf.Round(pos.x)/(float)chunkSize) * chunkSize;
		
		if(pos.y < 0)
			cy = (int) ((Mathf.Round(pos.y-chunkSize)+1)/(float)chunkSize) * chunkSize;
		else
			cy = (int) (Mathf.Round(pos.y)/(float)chunkSize) * chunkSize;
		
		if(pos.z < 0)
			cz = (int) ((Mathf.Round(pos.z-chunkSize)+1)/(float)chunkSize) * chunkSize;
		else
			cz = (int) (Mathf.Round(pos.z)/(float)chunkSize) * chunkSize;
	
		int blx = (int) Mathf.Abs((float)Math.Round(pos.x) - cx);
		int bly = (int) Mathf.Abs((float)Math.Round(pos.y) - cy);
		int blz = (int) Mathf.Abs((float)Math.Round(pos.z) - cz);

		string cn = BuildChunkName(new Vector3(cx,cy,cz));
		Chunk c;
		if(chunks.TryGetValue(cn, out c))
		{

			return c.chunkData[blx,bly,blz];
		}
		else
			return null;
	}