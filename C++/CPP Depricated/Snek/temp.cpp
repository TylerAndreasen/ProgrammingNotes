class Snake
{
private:
	/*
	* The head of the Snake.
	* Default value is bad, but gets overwritten in Constructor.
	*/
	Cell head{-1,-1};
	/*
	* The entire body of the Snake, including the head.
	* The head of the snake should always be stored at index 0.
	* This means that the Snake just moving will create a 
	*/
	vector<Cell> body;
	/*The number of cells the Snake still needs to grow on Update()*/
	int cellsToGrow = 0;
	int lastMoveDir = UP;

	int checkMoveDir(int newMoveDir)
	{
		if (lastMoveDir == UP && newMoveDir == DOWN)	return UP;
		if (lastMoveDir == RIGHT && newMoveDir == LEFT)	return RIGHT;
		if (lastMoveDir == DOWN && newMoveDir == UP)	return DOWN;
		if (lastMoveDir == LEFT && newMoveDir == RIGHT)	return LEFT;
		return newMoveDir;
	}

public:

	void Reset(int frameCount)
	{
		lastMoveDir = UP;
		lastScore = body.size();
		frameCountOfLastDeath = frameCount;
		while (!body.empty())
		{
			body.pop_back();
		}
		for (int i = 0; i < snakeStartLength; i++)
		{
			body.push_back(Cell(gridWidth / 2, i + (gridHeight / 2)));
		}
		head = body[0];

	}

	Snake()
	{
		this->Reset(0);
	}
	void Draw()
	{
		for (Cell c : body) c.Draw(snakeBody);
	}

	void AteApple()
	{
		cellsToGrow += 2;
	}

	Cell finallyGetSomeHead()
	{
		return this->head;
	}

	int bodyLength()
	{
		return this->body.size();
	}

	vector<Cell> getBodyRef() { return body;  }

	/*Used when the user gave no input since the last update*/
	void Update(int frameCount)
	{
		this->Update(lastMoveDir, frameCount);
	}

	/*Used when the user did input since the last update.*/
	int Update(int newMoveDir, int frameCount)
	{
		
		lastMoveDir = checkMoveDir(newMoveDir);


		// 0. Is the Snake dead?
		// 1. Logic for moving head to correct location
		// 2. What to do about the tail?

		// 0.
		int hx = this->head.getX(), hy = this->head.getY();

		/*
		cout << "Snake.Update, Head position: " << hx << ", " << hy << "   ";
		cout << "Snake.Update, Tail position: " << body.back().getX() << ", " << body.back().getX() << endl;
		cout << "Current To Grow : " << cellsToGrow << endl;
		*/

		if (hx < 0 || hx > gridWidth || hy < 0 || hy > gridHeight)
		{
			//cout << endl << "OUT_OF_BOUNDS DEATH" << endl;
			this->Reset(frameCount);
			return OUT_OF_BOUNDS;
		}

		for (int i = 1; i < body.size(); i++)
		{
			Cell b = body[i];
			if (b.compare(head))
			{
				/*
				cout << endl << "SELF_INTERSECT DEATH" << endl;
				cout << "Head Position : " << head.getX() << ", " << head.getY() << endl;
				cout << "Body Position : " << b.getX() << ", " << b.getY() << endl;
				*/
				this->Reset(frameCount);
				return SELF_INTERSECT;
			}
		}

		// 1. At this time, I am okay with if the player presses the opposite
		// direction of the current, they back the head into the previous cell
		// and die. I may change my mind later. 
		// After a bit of playtesting, I don't really like this, but don't have the energy to fix it.
		if (lastMoveDir == UP)			hy--;
		else if (lastMoveDir == RIGHT)	hx++;
		else if (lastMoveDir == DOWN)	hy++;
		else /*lastMoveDir = LEFT*/		hx--;
		

		//cout << "Snake.Update, *NEW* Head position: " << hx << ", " << hy << endl;

		Cell next{ hx,hy };
		body.insert(body.begin(), next);
		head = body[0];

		// 2.
		if (cellsToGrow > 0) cellsToGrow--;
		else
		{
			body.pop_back();
		}


		return ALIVE;
	}


};