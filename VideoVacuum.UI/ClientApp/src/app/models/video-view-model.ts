export interface YoutubeVideoViewModel {
  videoId: string;
  title: string;
  url: string;
  author: string;
  channelId: string;
  uploadDate: Date;
  description: string;
  duration: string;
  thumbnailUrl: string;
  keywords: string[];
  viewCount: number;
  likeCount: number;
  dislikeCount: number;
  averageRating: number;
  mP3FileName: string;
}
