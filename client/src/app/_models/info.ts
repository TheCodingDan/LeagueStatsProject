import { Participant } from "./participant";

export interface Info{
    gameCreation: number;
    gameDuration: number;
    gameEndTimeStamp: number;
    gameId: number;
    gameMode: string;
    gameName: string;
    gameVersion: string;
    mapId: number;
    participants: Participant[];
    queueId: number;
    tournamentCode: string;
}