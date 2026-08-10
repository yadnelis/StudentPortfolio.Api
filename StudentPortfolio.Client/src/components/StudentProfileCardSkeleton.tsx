import type { FC } from "react";
import { Skeleton, type SkeletonProps } from "./Skeleton";

export const StudentProfileCardSkeleton: FC<
  Omit<SkeletonProps, "className">
> = ({ visible, delay = 100, ...props }) => {
  return (
    <Skeleton
      className="h-100 bg-white px-10 w-[90dvw] max-w-300 py-7 min-h-fit"
      {...props}
      delay={delay}
      visible={visible}
    >
      <div className="space-y-2 pb-8">
        <Skeleton
          delay={delay}
          visible={visible}
          className="h-4 w-1/3 mb-5 bg-slate-300/50"
        />
        <Skeleton
          delay={delay}
          visible={visible}
          className="h-4 w-1/2 mb-5 bg-slate-300/50"
        />
      </div>
      <div className="space-y-7">
        <Skeleton delay={delay} className="h-8" visible={visible} />
        <Skeleton delay={delay} className="h-8" visible={visible} />
      </div>
      <div className="h-20 flex justify-end items-end">
        <Skeleton delay={delay} className="h-8 w-30" visible={visible} />
      </div>
    </Skeleton>
  );
};
