#include <iostream>
#include "snake.h"
using std::cout;
using std::endl;

const Color snake::snakeBody{ 20, 160, 133, 255 };

int snake::checkMoveDir(int newMoveDir)
{
	if (this->lastMoveDir == UP && newMoveDir == DOWN)	return UP;
	if (this->lastMoveDir == RIGHT && newMoveDir == LEFT)	return RIGHT;
	if (this->lastMoveDir == DOWN && newMoveDir == UP)	return DOWN;
	if (this->lastMoveDir == LEFT && newMoveDir == RIGHT)	return LEFT;
	return newMoveDir;
}

void snake::Reset(int frameCount)
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
		//body.push_back(cell(gridWidth / 2, i + (gridHeight / 2))); //Normal
		body.push_back(cell(1-i, gridHeight/2)); //Test
	}
	head = body[0];

}

snake::snake(int gridW, int gridH)
{
	this->gridHeight = gridH;
	this->gridWidth = gridW;
	this->Reset(0);
	this->lastMoveDir = RIGHT; //TEMP FOR TESTING
}
void snake::Draw()
{
	for (cell c : body) c.Draw(snakeBody);
}

void snake::AteApple()
{
	cout << "Ate an Apple, ";
	cellsToGrow += 2;
	cout << "new cellsToGrow : " << cellsToGrow << endl;
}

cell snake::finallyGetSomeHead()
{
	return this->head;
}

int snake::bodyLength()
{
	return this->body.size();
}

vector <cell > snake::getBodyRef() { return body; }

/*Used when the user gave no input since the last update*/
void snake::Update(int frameCount)
{
	this->Update(lastMoveDir, frameCount);
}

int snake::getCurrToGrow() { return cellsToGrow; }

/*Used when the user did input since the last update.*/
int snake::Update(int newMoveDir, int frameCount)
{
	cout << "Remaining cells to grow" << cellsToGrow << endl;
	lastMoveDir = checkMoveDir(newMoveDir);


	// 0. Is the Snake dead?
	// 1. Logic for moving head to correct location
	// 2. What to do about the tail?

	// 0.
	int hx = this->head.getX(), hy = this->head.getY();

	//*
	cout << "Snake.Update, Head position: " << hx << ", " << hy << "   ";
	cout << "Snake.Update, Tail position: " << body.back().getX() << ", " << body.back().getX() << endl;
	cout << "Current To Grow : " << cellsToGrow << endl;
	//*/

	if (hx < 0 || hx > gridWidth || hy < 0 || hy > gridHeight)
	{
		//cout << endl << "OUT_OF_BOUNDS DEATH" << endl;
		this->Reset(frameCount);
		return OUT_OF_BOUNDS;
	}

	for (int i = 1; i < body.size(); i++)
	{
		cell b = body[i];
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

	// The player's movement direction is limited by the checkMoveDir() method
	// which ignores any reverse direction input, avoid the head turning 180
	// and immediately killing the snake, as this is not interesting gameplay.
	if (lastMoveDir == UP)			hy--;
	else if (lastMoveDir == RIGHT)	hx++;
	else if (lastMoveDir == DOWN)	hy++;
	else /*lastMoveDir = LEFT*/ 	hx--;


	//cout << "Snake.Update, *NEW* Head position: " << hx << ", " << hy << endl;

	cell next{ hx,hy };
	body.insert(body.begin(), next);
	head = body[0];
	// 2.
	if (cellsToGrow > 0)
	{
		cellsToGrow--;
	}
	else
	{
		body.pop_back();
	}


	return ALIVE;
}