import { Plus } from "lucide-react";
import type { FC } from "react";
import { cn } from "../utilities/cs";
import { Button, type ButtonProps } from "./Button";

export const AddAcknowledgeButton: FC<
  Omit<ButtonProps, "color" | "children">
> = ({ className, ...rest }) => {
  return (
    <Button
      {...rest}
      color={"accent"}
      className={cn("not-group-hover/studentcard:bg-transparent", className)}
    >
      <span className="flex items-center gap-2">
        <Plus className="inline size-5" />{" "}
        <span className="max-sm:hidden">Acknowledge</span>
      </span>
    </Button>
  );
};
